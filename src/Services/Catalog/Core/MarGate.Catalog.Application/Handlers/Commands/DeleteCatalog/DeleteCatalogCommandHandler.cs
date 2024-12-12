using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Commands.DeleteCatalog;

public class DeleteCatalogCommandHandler : CommandHandler<DeleteCatalogCommandRequest, DeleteCatalogCommandResponse>
{
    public override Task<DeleteCatalogCommandResponse> Handle(DeleteCatalogCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
