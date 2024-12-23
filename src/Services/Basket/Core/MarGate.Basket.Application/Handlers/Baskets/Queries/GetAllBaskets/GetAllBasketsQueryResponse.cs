namespace MarGate.Basket.Application.Handlers.Basket.Queries.GetAllBaskets;

public class GetAllBasketsQueryResponse
{
    public long Id { get; set; }
    public long UsertId { get; set; }
    public List<GetAllBasketsQueryResponseBasketItem> Items { get; set; }
}

public class GetAllBasketsQueryResponseBasketItem
{
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
}
