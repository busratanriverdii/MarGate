using MarGate.Core.CQRS.Command;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Commands.CreateCampaign;

public class CreateCampaignCommandRequest : Command<CreateCampaignCommandResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
}
