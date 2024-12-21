using MarGate.Core.CQRS.Command;
using MarGate.Core.Mongo;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Commands.CreateCampaign;

public class CreateCampaignCommandHandler(IMongoRepositoryFactory mongoRepositoryFactory) : CommandHandler<CreateCampaignCommandRequest, CreateCampaignCommandResponse>
{
    private readonly IMongoRepository<Domain.Entities.Campaign> _campaignRepository = mongoRepositoryFactory.CreateRepository<Domain.Entities.Campaign>();

    public async override Task<CreateCampaignCommandResponse> Handle(CreateCampaignCommandRequest request,
        CancellationToken cancellationToken)
    {
        var campaign = new Domain.Entities.Campaign(
            request.Name,
            request.Description,
            request.DiscountPercentage,
            request.StartDate,
            request.EndDate,
            request.IsActive
        );

        await _campaignRepository.AddAsync(campaign, cancellationToken);

        return new CreateCampaignCommandResponse
        {
            IsSuccess = true
        };
    }
}
