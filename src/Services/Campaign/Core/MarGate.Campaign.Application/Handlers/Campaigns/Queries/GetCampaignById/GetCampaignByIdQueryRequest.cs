using MarGate.Core.CQRS.Query;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Queries.GetCampaignById;

public class GetCampaignByIdQueryRequest : Query<GetCampaignByIdQueryResponse>
{
    public string Id { get; set; }
}
