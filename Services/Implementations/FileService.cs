using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SmartOrderSystem.Data;
using SmartOrderSystem.DTOs;
using SmartOrderSystem.Services.Interfaces;

namespace SmartOrderSystem.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public FileService(IWebHostEnvironment env, AppDbContext context)
        {
            _env = env;
            _context = context;
        }

        // existing methods...

        public Task<string> SaveFileAsync(IFormFile file)
        {
            var uploadsFolder = Path.Combine(_env.ContentRootPath, "Uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            return Task.FromResult(filePath);
        }

        public Task<List<BulkOrderRow>> ReadCsvAsync(string path)
        {
            var lines = File.ReadAllLines(path);

            var result = new List<BulkOrderRow>();

            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(',');
                if (values.Length < 3)
                    continue;

                result.Add(new BulkOrderRow
                {
                    CustomerId = int.Parse(values[0]),
                    ProductId = int.Parse(values[1]),
                    Quantity = int.Parse(values[2])
                });
            }

            return Task.FromResult(result);
        }

        public Task<List<BulkOrderRow>> ReadExcelAsync(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var result = new List<BulkOrderRow>();

            using var package = new ExcelPackage(new FileInfo(path));
            var sheet = package.Workbook.Worksheets[0];
            if (sheet.Dimension == null)
                return Task.FromResult(result);

            int rowCount = sheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                result.Add(new BulkOrderRow
                {
                    CustomerId = int.Parse(sheet.Cells[row, 1].Text),
                    ProductId = int.Parse(sheet.Cells[row, 2].Text),
                    Quantity = int.Parse(sheet.Cells[row, 3].Text)
                });
            }

            return Task.FromResult(result);
        }


        public async Task<FileImportResult> ValidateAndParseOrders(string filePath)
        {
            var result = new FileImportResult();

            var lines = await File.ReadAllLinesAsync(filePath);

            var seenRows = new HashSet<string>();

            for (int i = 1; i < lines.Length; i++)
            {
                var columns = lines[i].Split(',');
                if (columns.Length < 3)
                {
                    result.InvalidOrders.Add(new InvalidOrderDto
                    {
                        RowNumber = i + 1,
                        ErrorMessage = "Invalid row format"
                    });
                    continue;
                }

                var customerIdText = columns[0];
                var productIdText = columns[1];
                var quantityText = columns[2];


                if (string.IsNullOrWhiteSpace(customerIdText) ||
                    string.IsNullOrWhiteSpace(productIdText) ||
                    string.IsNullOrWhiteSpace(quantityText))
                {
                    result.InvalidOrders.Add(new InvalidOrderDto
                    {
                        RowNumber = i + 1,
                        ErrorMessage = "Missing required fields"
                    });
                    continue;
                }

                if (!int.TryParse(customerIdText, out int customerId) ||
                    !int.TryParse(productIdText, out int productId) ||
                    !int.TryParse(quantityText, out int quantity))
                {
                    result.InvalidOrders.Add(new InvalidOrderDto
                    {
                        RowNumber = i + 1,
                        ErrorMessage = "Invalid numeric values"
                    });
                    continue;
                }
                var customerExists = await _context.Customers.AnyAsync(c => c.Id == customerId);
                if (!customerExists)
                {
                    result.InvalidOrders.Add(new InvalidOrderDto
                    {
                        RowNumber = i + 1,
                        ErrorMessage = "Customer does not exist"
                    });
                    continue;
                }

                var productExists = await _context.Products.AnyAsync(p => p.Id == productId);
                if (!productExists)
                {
                    result.InvalidOrders.Add(new InvalidOrderDto
                    {
                        RowNumber = i + 1,
                        ErrorMessage = "Product does not exist"
                    });
                    continue;
                }

                if (quantity <= 0)
                {
                    result.InvalidOrders.Add(new InvalidOrderDto
                    {
                        RowNumber = i + 1,
                        ErrorMessage = "Quantity must be greater than 0"
                    });
                    continue;
                }

                var key = $"{customerId}-{productId}";
                if (seenRows.Contains(key))
                {
                    result.InvalidOrders.Add(new InvalidOrderDto
                    {
                        RowNumber = i + 1,
                        ErrorMessage = "Duplicate entry found"
                    });
                    continue;
                }

                seenRows.Add(key);

                result.ValidOrders.Add(new ValidOrderDto
                {
                    CustomerId = customerId,
                    Items = new List<OrderItemRequest>
                {
                    new OrderItemRequest
                    {
                        ProductId = productId,
                        Quantity = quantity
                    }
                }
                });
            }


            return result;
        }
    }
}