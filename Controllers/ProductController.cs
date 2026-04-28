using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartOrderSystem.DTOs;
using SmartOrderSystem.Models;
using SmartOrderSystem.Services.Implementations;
using SmartOrderSystem.Services.Interfaces;

namespace SmartOrderSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();

            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            var created = await _productService.CreateAsync(product);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            var updated = await _productService.UpdateAsync(id, product);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return Ok("Deleted successfully");
        }
    }
}