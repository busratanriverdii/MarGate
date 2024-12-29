using MarGate.Catalog.Application.Handlers.Products.Commands.CreateCatalog;
using MarGate.Catalog.Domain.Entities;
using MarGate.Core.CQRS.Command;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Catalog.Application.Handlers.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IWriteRepository<Product> _productWriteRepository = unitOfWork.GetWriteRepository<Product>();

    public override Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.UnitsInStock, request.Price, request.CategoryId);

        _productWriteRepository.Create(product);

        return Task.FromResult(new CreateProductCommandResponse()
        {
            IsSuccess = true,
            ProductId = product.Id
        });
    }
}
