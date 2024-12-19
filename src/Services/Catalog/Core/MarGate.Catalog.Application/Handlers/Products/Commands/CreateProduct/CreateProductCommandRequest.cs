using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Products.Commands.CreateCatalog;

public class CreateProductCommandRequest : Command<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public int UnitsInStock { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
}
