using System.ComponentModel.DataAnnotations;

namespace SmartOrderSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}