using MarGate.Catalog.Application.Handlers.Products.Commands.CreateCatalog;
using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : CommandHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;

    public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public override Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Name = request.Name,
            Price = request.Price,
            UnitsInStock = request.UnitsInStock,
            CategoryId = request.CategoryId
        };

        var isSuccess = await _productWriteRepository.CreateAsync(product);
        await _productWriteRepository.SaveAsync();

        return new CreateProductCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
