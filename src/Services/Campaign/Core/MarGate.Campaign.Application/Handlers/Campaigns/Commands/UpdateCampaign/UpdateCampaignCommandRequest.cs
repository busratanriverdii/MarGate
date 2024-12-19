using MarGate.Core.CQRS.Command;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Commands.UpdateCampaign;

public class UpdateCampaignCommandRequest : Command<UpdateCampaignCommandResponse>
{
    public long Id { get; set; }
}
