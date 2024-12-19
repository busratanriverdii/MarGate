using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : CommandHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
{
    private readonly ICategoryWriteRepository _categoryWriteRepository;

    public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryWriteRepository = categoryWriteRepository;
    }

    public override Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var category = new Category()
        {
            Name = request.Name,
            Description = request.Description
        };

        var isSuccess = await _categoryWriteRepository.CreateAsync(category);
        await _categoryWriteRepository.SaveAsync();

        return new CreateCategoryCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
