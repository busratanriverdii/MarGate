namespace MarGate.Catalog.Application.Handlers.Products.Queries.GetCatalogById;

public class GetProductByIdQueryResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int UnitsInStock { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
}
