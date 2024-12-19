using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Products.Commands.DeleteCatalog;

public class DeleteProductCommandRequest : Command<DeleteProductCommandResponse>
{
    public long Id { get; set; }
}
