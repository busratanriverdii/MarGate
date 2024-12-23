using MarGate.Campaign.Application.Handlers.Campaigns.Commands.CreateCampaign;
using MarGate.Campaign.Domain.Entities;
using MarGate.Core.CQRS.Command;
using MarGate.Core.Mongo;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Commands.DeleteCampaign;

public class DeleteCampaignCommandHandler(IMongoRepositoryFactory mongoRepositoryFactory) : CommandHandler<DeleteCampaignCommandRequest, DeleteCampaignCommandResponse>
{
    private readonly IMongoRepository<Domain.Entities.Campaign> _campaignRepository = mongoRepositoryFactory.CreateRepository<Domain.Entities.Campaign>();

    public async override Task<DeleteCampaignCommandResponse> Handle(DeleteCampaignCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var campaign = await _campaignRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        await _campaignRepository.DeleteAsync(campaign, cancellationToken);

        return new DeleteCampaignCommandResponse
        {
            IsSuccess = true
        };

    }
}
