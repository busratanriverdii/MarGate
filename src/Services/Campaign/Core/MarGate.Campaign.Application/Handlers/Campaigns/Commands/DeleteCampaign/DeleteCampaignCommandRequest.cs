using MarGate.Core.CQRS.Command;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Commands.DeleteCampaign;

public class DeleteCampaignCommandRequest : Command<DeleteCampaignCommandResponse>
{
    public long Id { get; set; }
}
