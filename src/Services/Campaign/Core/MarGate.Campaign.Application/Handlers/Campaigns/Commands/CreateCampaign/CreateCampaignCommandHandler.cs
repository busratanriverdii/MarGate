using MarGate.Core.CQRS.Command;

namespace MarGate.Campaign.Application.Handlers.Campaigns.Commands.CreateCampaign;

public class CreateCampaignCommandHandler : CommandHandler<CreateCampaignCommandRequest, CreateCampaignCommandResponse>
{
    private readonly ICampaignWriteRepository _campaignWriteRepository;

    public CreateCampaignCommandHandler(ICampaignWriteRepository campaignWriteRepository)
    {
        _campaignWriteRepository = campaignWriteRepository;
    }

    public override Task<CreateCampaignCommandResponse> Handle(CreateCampaignCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var discount = new Discount(request.DiscountPercentage);
        var campaign = new Campaign(
            request.Name,
            request.Description,
            discount,
            request.StartDate,
            request.EndDate,
            request.IsActive
        );

        // MongoDB 
        var isSuccess = await _campaignWriteRepository.CreateAsync(campaign);

        await _campaignWriteRepository.SaveAsync();

        return new CreateCampaignCommandResponse
        {
            IsSuccess = isSuccess
        };
    }
}
