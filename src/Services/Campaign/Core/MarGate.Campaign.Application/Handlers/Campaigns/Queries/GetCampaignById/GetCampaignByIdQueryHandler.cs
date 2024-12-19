using MarGate.Core.CQRS.Query;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Queries.GetCampaignById;

public class GetCampaignByIdQueryHandler : QueryHandler<GetCampaignByIdQueryRequest, GetCampaignByIdQueryResponse>
{
    private readonly ICampaignReadRepository _campaignReadRepository;

    public GetCampaignByIdQueryHandler(ICampaignReadRepository campaignReadRepository)
    {
        _campaignReadRepository = campaignReadRepository;
    }

    public override Task<GetCampaignByIdQueryResponse> Handle(GetCampaignByIdQueryRequest request, 
        CancellationToken cancellationToken)
    {
        var campaign = await _campaignReadRepository.FindByIdAsync(request.CampaignId);
        if (campaign == null)
        {
            return null; 
        }

        return new GetCampaignByIdQueryResponse
        {
            Id = campaign.Id,
            Name = campaign.Name,
            Description = campaign.Description,
            DiscountPercentage = campaign.Discount.Percentage,
            StartDate = campaign.StartDate,
            EndDate = campaign.EndDate,
            IsActive = campaign.IsActive
        };
    }
}
