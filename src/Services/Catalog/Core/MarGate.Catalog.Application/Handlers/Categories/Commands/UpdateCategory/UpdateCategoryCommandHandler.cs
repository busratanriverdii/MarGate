using MarGate.Catalog.Domain.Entities;
using MarGate.Core.CQRS.Command;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Catalog.Application.Handlers.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
{
    private readonly IWriteRepository<Category> _categoryWriteRepository = unitOfWork.GetWriteRepository<Category>();

    public async override Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        category.ChangeCategoryName(request.Name);
        category.ChangeCategoryDescription(request.Description);

        var isSuccess = _categoryWriteRepository.Update(category);

        return new UpdateCategoryCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
