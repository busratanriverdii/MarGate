using MarGate.Core.CQRS.Query;

namespace MarGate.Catalog.Application.Handlers.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : QueryHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
{
    private readonly ICategoryReadRepository _categoryReadRepository;

    public GetCategoryByIdQueryHandler(ICategoryReadRepository categoryReadRepository)
    {
        _categoryReadRepository = categoryReadRepository;
    }

    public override Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var category = await _categoryReadRepository.GetByIdAsync(request.Id);
        return new GetCategoryByIdQueryResponse()
        {
            Id = category.Id,
            Name = category.Name

            // set description?
        };
    }
}
