using Microsoft.EntityFrameworkCore;
using SmartOrderSystem.Data;
using SmartOrderSystem.DTOs;
using SmartOrderSystem.Models;
using SmartOrderSystem.Services.Interfaces;

namespace SmartOrderSystem.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)                
                .Include(o => o.OrderItems)              
                    .ThenInclude(oi => oi.Product)        
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        //public async Task<Order> CreateAsync(Order order)
        //{
        //    order.OrderDate = DateTime.Now;

        //    _context.Orders.Add(order);
        //    await _context.SaveChangesAsync();

        //    return await _context.Orders
        //        .Include(o => o.OrderItems)
        //        .FirstOrDefaultAsync(o => o.Id == order.Id);
        //}

        public async Task<Order> CreateOrder(CreateOrderRequest request)
        {
            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in request.Items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);

                if (product == null)
                    throw new Exception("Product not found");

                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = product.Price
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
        public async Task<Order?> UpdateOrder(int orderId, UpdateOrderRequest request)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                return null;

            // remove old items
            _context.OrderItems.RemoveRange(order.OrderItems);

            order.OrderItems = new List<OrderItem>();

            foreach (var item in request.Items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);

                if (product == null)
                    throw new Exception("Product not found");

                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = product.Price
                });
            }

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}