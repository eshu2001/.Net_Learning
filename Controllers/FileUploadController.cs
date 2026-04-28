using Microsoft.AspNetCore.Mvc;
using SmartOrderSystem.Services.Interfaces;

namespace SmartOrderSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IOrderService _orderService;

        public FileUploadController(IFileService fileService, IOrderService orderService)
        {
            _fileService = fileService;
            _orderService = orderService;
        }

        [HttpPost("bulk-orders")]
        public async Task<IActionResult> UploadBulkOrders(IFormFile file)
        {
            //Validate file exists
            if (file == null || file.Length == 0)
                return BadRequest("File is empty");

            //Validate file size (5MB max)
            if (file.Length > 5 * 1024 * 1024)
                return BadRequest("File too large");

            //Validate file type
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (extension != ".csv" && extension != ".xlsx")
                return BadRequest("Only CSV or Excel allowed");

            //Save file
            var path = await _fileService.SaveFileAsync(file);

            //Read file
            var rows = extension == ".csv"
                ? await _fileService.ReadCsvAsync(path)
                : await _fileService.ReadExcelAsync(path);

            //Convert rows → Orders
            foreach (var row in rows)
            {
                await _orderService.CreateOrder(new DTOs.CreateOrderRequest
                {
                    CustomerId = row.CustomerId,
                    Items = new List<DTOs.OrderItemRequest>
                    {
                        new DTOs.OrderItemRequest
                        {
                            ProductId = row.ProductId,
                            Quantity = row.Quantity
                        }
                    }
                });
            }

            return Ok("Bulk orders uploaded successfully!!!");
        }
        [HttpPost("upload-validate")]
        public async Task<IActionResult> UploadAndValidate(IFormFile file)
        {
            var path = await _fileService.SaveFileAsync(file);

            var result = await _fileService.ValidateAndParseOrders(path);

            return Ok(result);
        }
    }
}