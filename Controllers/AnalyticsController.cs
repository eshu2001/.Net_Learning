using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartOrderSystem.Data;

namespace SmartOrderSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnalyticsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("orders-per-customer")]
        public async Task<IActionResult> OrdersPerCustomer()
        {
            var result = await _context.Orders
                .GroupBy(o => o.CustomerId)
                .Select(g => new
                {
                    CustomerId = g.Key,
                    TotalOrders = g.Count()
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("highest-selling-product")]
        public async Task<IActionResult> HighestSellingProduct()
        {
            var result = await _context.OrderItems
                .Include(oi => oi.Product)
                .GroupBy(oi => oi.Product.Name)
                .Select(g => new
                {
                    ProductName = g.Key,
                    TotalSold = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.TotalSold)
                .FirstOrDefaultAsync();

            return Ok(result);
        }

        [HttpGet("high-value-orders")]
        public async Task<IActionResult> HighValueOrders()
        {
            var result = await _context.Orders
                .Include(o => o.OrderItems)
                .Select(o => new
                {
                    o.Id,
                    TotalAmount = o.OrderItems.Sum(i => i.Price * i.Quantity)
                })
                .Where(o => o.TotalAmount > 10000)
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("orders-by-month")]
        public async Task<IActionResult> OrdersByMonth()
        {
            var result = await _context.Orders
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    TotalOrders = g.Count()
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("full-order-details")]
        public async Task<IActionResult> FullOrderDetails()
        {
            var result = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Select(o => new
                {
                    CustomerName = o.Customer.Name,
                    OrderId = o.Id,
                    Products = o.OrderItems.Select(i => new
                    {
                        i.Product.Name,
                        i.Quantity,
                        i.Price
                    }),
                    TotalAmount = o.OrderItems.Sum(i => i.Price * i.Quantity)
                })
                .ToListAsync();

            return Ok(result);
        }

    }
}