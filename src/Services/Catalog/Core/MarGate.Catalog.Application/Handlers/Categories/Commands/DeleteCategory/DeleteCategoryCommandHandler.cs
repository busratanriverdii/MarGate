using MarGate.Catalog.Domain.Entities;
using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Catalog.Application.Handlers.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
{
    private readonly IWriteRepository<Category> _categoryWriteRepository = unitOfWork.GetWriteRepository<Category>();

    public async override Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        category.MarkAsDeleted();

        var isSuccess = _categoryWriteRepository.Update(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteCategoryCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
