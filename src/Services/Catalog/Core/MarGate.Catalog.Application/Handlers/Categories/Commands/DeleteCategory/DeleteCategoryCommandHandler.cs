using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : CommandHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
{
    private readonly ICategoryWriteRepository _categoryWriteRepository;

    public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
    }
    public override Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var category = await _categoryWriteRepository.FindAsync(request.Id);
        category.IsDeleted = true;

        var isSuccess = _categoryWriteRepository.Update(category);
        await _categoryWriteRepository.SaveAsync();

        return new DeleteCategoryCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
