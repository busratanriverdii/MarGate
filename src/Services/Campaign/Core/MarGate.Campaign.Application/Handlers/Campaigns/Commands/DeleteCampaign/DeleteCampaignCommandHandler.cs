using MarGate.Core.CQRS.Command;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Commands.DeleteCampaign;

public class DeleteCampaignCommandHandler : CommandHandler<DeleteCampaignCommandRequest, DeleteCampaignCommandResponse>
{
    private readonly ICampaignWriteRepository _campaignWriteRepository;

    public DeleteCampaignCommandHandler(ICampaignWriteRepository campaignWriteRepository)
    {
        _campaignWriteRepository = campaignWriteRepository;
    }

    public override Task<DeleteCampaignCommandResponse> Handle(DeleteCampaignCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var isSuccess = await _campaignWriteRepository.DeleteAsync(request.CampaignId);

        await _campaignWriteRepository.SaveAsync();

        return new DeleteCampaignCommandResponse
        {
            IsSuccess = isSuccess
        };
    }
}
