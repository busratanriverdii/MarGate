using MarGate.Core.CQRS.Command;
using MediatR;

namespace MarGate.Catalog.Application.Handlers.Commands.CreateCatalog;

public class CreateCatalogCommandHandler : CommandHandler<CreateCatalogCommandRequest, CreateCatalogCommandResponse>
{
    public override Task<CreateCatalogCommandResponse> Handle(CreateCatalogCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
