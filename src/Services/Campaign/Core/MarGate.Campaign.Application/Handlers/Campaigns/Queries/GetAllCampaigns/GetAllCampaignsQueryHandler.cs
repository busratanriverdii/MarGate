using MarGate.Core.CQRS.Query;
using MarGate.Core.Mongo;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Queries.GetAllCampaigns;

public class GetAllCampaignsQueryHandler(IMongoRepositoryFactory mongoRepositoryFactory) : QueryHandler<GetAllCampaignsQueryRequest, List<GetAllCampaignsQueryResponse>>
{
    private readonly IMongoRepository<Domain.Entities.Campaign> _campaignRepository = mongoRepositoryFactory.CreateRepository<Domain.Entities.Campaign>();

    public async override Task<List<GetAllCampaignsQueryResponse>> Handle(GetAllCampaignsQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var campaigns = await _campaignRepository.GetListAsync(cancellationToken: cancellationToken);

        return campaigns.Select(c => new GetAllCampaignsQueryResponse
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            DiscountPercentage = c.DiscountRate,
            StartDate = c.StartDate,
            EndDate = c.EndDate,
            IsActive = c.IsActive
        }).ToList();
    }
}
