using MarGate.Catalog.Application.Handlers.Products.Commands.CreateCatalog;
using MarGate.Catalog.Domain.Entities;
using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Catalog.Application.Handlers.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IWriteRepository<Product> _productWriteRepository = unitOfWork.GetWriteRepository<Product>();

    public async override Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.UnitsInStock, request.Price, request.CategoryId);

        var id = _productWriteRepository.Create(product);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateProductCommandResponse()
        {
            IsSuccess = true,
            ProductId = id
        };
    }
}
