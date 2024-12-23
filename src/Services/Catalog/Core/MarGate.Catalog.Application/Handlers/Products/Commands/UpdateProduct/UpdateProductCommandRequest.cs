using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Products.Commands.UpdateCatalog;

public class UpdateProductCommandRequest : Command<UpdateProductCommandResponse>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int UnitsInStock { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
}
