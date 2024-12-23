using MarGate.Catalog.Domain.Entities;
using MarGate.Core.CQRS.Query;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Catalog.Application.Handlers.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
{
    private readonly IReadRepository<Category> _categoryReadRepository = unitOfWork.GetReadRepository<Category>();

    public async override Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryReadRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return new GetCategoryByIdQueryResponse()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
}
