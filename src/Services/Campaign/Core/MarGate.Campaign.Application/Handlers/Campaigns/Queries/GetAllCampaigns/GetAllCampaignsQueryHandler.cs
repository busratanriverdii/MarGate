using MarGate.Core.CQRS.Query;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Queries.GetAllCampaigns;

public class GetAllCampaignsQueryHandler : QueryHandler<GetAllCampaignsQueryRequest, List<GetAllCampaignsQueryResponse>>
{
    private readonly ICampaignReadRepository _campaignReadRepository;

    public GetAllCampaignsQueryHandler(ICampaignReadRepository campaignReadRepository)
    {
        _campaignReadRepository = campaignReadRepository;
    }

    public override Task<List<GetAllCampaignsQueryResponse>> Handle(GetAllCampaignsQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var campaigns = await _campaignReadRepository.GetAll().ToListAsync(cancellationToken);

        return campaigns.Select(campaign => new GetAllCampaignsQueryResponse
        {
            Id = campaign.Id,
            Name = campaign.Name,
            Description = campaign.Description,
            DiscountPercentage = campaign.Discount.Percentage,
            StartDate = campaign.StartDate,
            EndDate = campaign.EndDate,
            IsActive = campaign.IsActive
        }).ToList();
    }
}
