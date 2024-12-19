using MarGate.Core.CQRS.Command;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Commands.UpdateCampaign;

public class UpdateCampaignCommandHandler : CommandHandler<UpdateCampaignCommandRequest, UpdateCampaignCommandResponse>
{
    private readonly ICampaignWriteRepository _campaignWriteRepository;

    public UpdateCampaignCommandHandler(ICampaignWriteRepository campaignWriteRepository)
    {
        _campaignWriteRepository = campaignWriteRepository;
    }

    public override Task<UpdateCampaignCommandResponse> Handle(UpdateCampaignCommandRequest request,
        CancellationToken cancellationToken)
    {
        var campaign = await _campaignWriteRepository.FindAsync(request.CampaignId);
        if (campaign == null)
        {
            return new UpdateCampaignCommandResponse
            {
                IsSuccess = false
            };
        }

        campaign.UpdateDetails(
            request.Name,
            request.Description,
            new Discount(request.DiscountPercentage),
            request.StartDate,
            request.EndDate,
            request.IsActive
        );
        var isSuccess = _campaignWriteRepository.Update(campaign);

        await _campaignWriteRepository.SaveAsync();

        return new UpdateCampaignCommandResponse
        {
            IsSuccess = isSuccess
        };
    }
}
