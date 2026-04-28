using SmartOrderSystem.DTOs;
using SmartOrderSystem.Models;

namespace SmartOrderSystem.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
       // Task<Order> CreateAsync(Order order);
        Task<Order> CreateOrder(CreateOrderRequest request);
        Task<Order?> UpdateOrder(int id, UpdateOrderRequest request);
        Task<bool> DeleteAsync(int id);
    }
}