using MarGate.Catalog.Domain.Entities;
using MarGate.Core.CQRS.Command;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Catalog.Application.Handlers.Products.Commands.DeleteCatalog;

public class DeleteProductCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    private readonly IWriteRepository<Product> _productWriteRepository = unitOfWork.GetWriteRepository<Product>();

    public async override Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _productWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        product.MarkAsDeleted();

        var isSuccess = _productWriteRepository.Update(product);

        return new DeleteProductCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
