using MarGate.Core.CQRS.Command;
using MarGate.Core.Mongo;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Commands.UpdateCampaign;

public class UpdateCampaignCommandHandler(IMongoRepositoryFactory mongoRepositoryFactory) : CommandHandler<UpdateCampaignCommandRequest, UpdateCampaignCommandResponse>
{
    private readonly IMongoRepository<Domain.Entities.Campaign> _campaignRepository = mongoRepositoryFactory.CreateRepository<Domain.Entities.Campaign>();

    public async override Task<UpdateCampaignCommandResponse> Handle(UpdateCampaignCommandRequest request,
        CancellationToken cancellationToken)
    {
        var campaign = await _campaignRepository.FirstOrDefaultAsync(x => x.Id == request.Id);
        campaign.SetName(request.Name);
        campaign.SetDescription(request.Description);
        campaign.SetDiscountRate(request.DiscountPercentage);
        campaign.SetCampaignIntervalDate(request.StartDate, request.EndDate);
        campaign.MarkAsModified();

        await _campaignRepository.UpdateAsync(campaign, cancellationToken);

        return new UpdateCampaignCommandResponse
        {
            IsSuccess = true
        };
    }
}
