using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Products.Commands.DeleteCatalog;

public class DeleteProductCommandHandler : CommandHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;

    public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public override Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var product = await _productWriteRepository.FindAsync(request.Id);
        product.IsDeleted = true;

        var isSuccess = _productWriteRepository.Update(product);
        await _productWriteRepository.SaveAsync();

        return new DeleteProductCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
