using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Commands.DeleteCatalog;

public class DeleteCatalogCommandRequest : Command<DeleteCatalogCommandResponse>
{
    public long Id { get; set; }
}
