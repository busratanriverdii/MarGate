using MarGate.Core.CQRS.Query;
using MarGate.Core.Mongo;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Queries.GetCampaignById;

public class GetCampaignByIdQueryHandler(IMongoRepositoryFactory mongoRepositoryFactory) : QueryHandler<GetCampaignByIdQueryRequest, GetCampaignByIdQueryResponse>
{
    private readonly IMongoRepository<Domain.Entities.Campaign> _campaignRepository = mongoRepositoryFactory.CreateRepository<Domain.Entities.Campaign>();
    public async override Task<GetCampaignByIdQueryResponse> Handle(GetCampaignByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var campaign = await _campaignRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (campaign == null) return null;

        return new GetCampaignByIdQueryResponse
        {
            Id = campaign.Id,
            Name = campaign.Name,
            Description = campaign.Description,
            DiscountPercentage = campaign.DiscountRate,
            StartDate = campaign.StartDate,
            EndDate = campaign.EndDate,
            IsActive = campaign.IsActive
        };
    }
}
