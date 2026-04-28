using Microsoft.AspNetCore.Mvc;
using SmartOrderSystem.DTOs;
using SmartOrderSystem.Models;
using SmartOrderSystem.Services;
using SmartOrderSystem.Services.Interfaces;

namespace SmartOrderSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET all customers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        // GET by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();

            return Ok(customer);
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequest request)
        {
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email
            };

            var created = await _customerService.CreateAsync(customer);
            return Ok(created);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Customer customer)
        {
            var updated = await _customerService.UpdateAsync(id, customer);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _customerService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return Ok("Deleted successfully");
        }
    }
}