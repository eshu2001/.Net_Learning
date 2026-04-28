namespace SmartOrderSystem.DTOs
{
    public class FileImportResult
    {
        public List<ValidOrderDto> ValidOrders { get; set; } = new();
        public List<InvalidOrderDto> InvalidOrders { get; set; } = new();
    }

    public class ValidOrderDto
    {
        public int CustomerId { get; set; }
        public List<OrderItemRequest> Items { get; set; } = new();
    }

    public class InvalidOrderDto
    {
        public int RowNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
}