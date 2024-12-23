namespace MarGate.Order.Api.Requests
{
    public class CreateOrderRequest
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public long UserId { get; set; }
        public List<CreateOrderRequestItem> Items { get; set; }
    }

    public class CreateOrderRequestItem
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
