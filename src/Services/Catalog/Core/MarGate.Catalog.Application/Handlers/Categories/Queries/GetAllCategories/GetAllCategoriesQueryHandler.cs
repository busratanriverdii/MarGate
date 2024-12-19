using MarGate.Core.CQRS.Query;

namespace MarGate.Catalog.Application.Handlers.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : QueryHandler<GetAllCategoriesQueryRequest, List<GetAllCategoriesQueryResponse>>
{
    private readonly ICategoryReadRepository _categoryReadRepository;

    public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository)
    {
        _categoryReadRepository = categoryReadRepository;
    }

    public override Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var categories = await _categoryReadRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);

        return categories.Select(c => new GetAllCategoriesQueryResponse()
        {
            Id = c.Id,
            Name = c.Name

            // description ?
        }).ToList();
    }
}
