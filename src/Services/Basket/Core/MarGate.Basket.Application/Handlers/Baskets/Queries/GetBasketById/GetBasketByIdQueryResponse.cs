namespace MarGate.Basket.Application.Handlers.Basket.Queries.GetBasketById;

public class GetBasketByIdQueryResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public List<GetBasketByIdQueryResponseBasketItem> Items { get; set; }
}

public class GetBasketByIdQueryResponseBasketItem
{
    public long ProductId { get;  set; }
    public int Quantity { get;  set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
}
