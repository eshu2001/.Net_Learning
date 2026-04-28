namespace SmartOrderSystem.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalAmount
        {
            get
            {
                if (OrderItems == null || !OrderItems.Any())
                    return 0;

                return OrderItems.Sum(i => i.Price * i.Quantity);
            }
        }
    }
}