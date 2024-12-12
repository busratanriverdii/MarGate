using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Commands.UpdateCatalog;

public class UpdateCatalogCommandHandler : CommandHandler<UpdateCatalogCommandRequest, UpdateCatalogCommandResponse>
{
    public override Task<UpdateCatalogCommandResponse> Handle(UpdateCatalogCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
