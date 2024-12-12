using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Commands.CreateCatalog;

public class CreateCatalogCommandRequest : Command<CreateCatalogCommandResponse>
{
    public string Name { get; set; }
    public int UnitsInStock { get; set; }
    public decimal Price { get; set; }
    // public long CategoryId { get; set; }
}
