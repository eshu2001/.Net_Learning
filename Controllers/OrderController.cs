using Microsoft.AspNetCore.Mvc;
using SmartOrderSystem.DTOs;
using SmartOrderSystem.Models;
using SmartOrderSystem.Services.Interfaces;

namespace SmartOrderSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null) return NotFound();

            return Ok(order);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(Order order)
        //{
        //    var created = await _orderService.CreateAsync(order);
        //    return Ok(created);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var result = await _orderService.CreateOrder(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderRequest request)
        {
            var updated = await _orderService.UpdateOrder(id, request);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _orderService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return Ok("Deleted successfully");
        }
    }
}