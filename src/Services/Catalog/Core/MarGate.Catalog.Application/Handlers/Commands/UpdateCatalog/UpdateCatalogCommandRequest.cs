using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Commands.UpdateCatalog;

public class UpdateCatalogCommandRequest : Command<UpdateCatalogCommandResponse>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int UnitsInStock { get; set; }
    public decimal Price { get; set; }
    //public long CategoryId { get; set; }
}
