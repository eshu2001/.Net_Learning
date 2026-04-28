using System.ComponentModel.DataAnnotations;

namespace SmartOrderSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        //public List<OrderItem> OrderItems { get; set; }
    }
}