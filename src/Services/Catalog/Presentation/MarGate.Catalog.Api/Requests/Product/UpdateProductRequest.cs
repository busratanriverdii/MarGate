namespace MarGate.Catalog.Api.Requests.Product
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
    }
}
