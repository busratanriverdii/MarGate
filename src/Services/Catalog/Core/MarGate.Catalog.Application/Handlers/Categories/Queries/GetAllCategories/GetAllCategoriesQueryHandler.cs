using MarGate.Catalog.Domain.Entities;
using MarGate.Core.CQRS.Query;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

namespace MarGate.Catalog.Application.Handlers.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork) : QueryHandler<GetAllCategoriesQueryRequest, List<GetAllCategoriesQueryResponse>>
{
    private readonly IReadRepository<Category> _categoryReadRepository = unitOfWork.GetReadRepository<Category>();

    public async override Task<List<GetAllCategoriesQueryResponse>> Handle(
        GetAllCategoriesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var categories = await _categoryReadRepository.GetListAsync(cancellationToken: cancellationToken);

        return categories.Select(c => new GetAllCategoriesQueryResponse()
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        }).ToList();
    }
}
