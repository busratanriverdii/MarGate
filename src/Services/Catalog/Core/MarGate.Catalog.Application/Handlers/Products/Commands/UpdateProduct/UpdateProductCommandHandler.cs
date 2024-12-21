using MarGate.Catalog.Domain.Entities;
using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Catalog.Application.Handlers.Products.Commands.UpdateCatalog;

public class UpdateProductCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IWriteRepository<Product> _productWriteRepository = unitOfWork.GetWriteRepository<Product>();

    public async override Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _productWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        product.SetName(request.Name);
        product.SetPrice(request.Price);
        product.SetUnitsInStock(request.UnitsInStock);
        product.SetCategoryId(request.CategoryId);

        var isSuccess = _productWriteRepository.Update(product);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateProductCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}

