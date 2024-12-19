using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : CommandHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
{
    private readonly ICategoryWriteRepository _categoryWriteRepository;

    public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
    }

    public override Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var category = await _categoryWriteRepository.FindAsync(request.Id);

        category.Name = request.Name;
        category.Description = request.Description;

        var isSuccess = _categoryWriteRepository.Update(category);
        await _categoryWriteRepository.SaveAsync();

        return new UpdateCategoryCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
