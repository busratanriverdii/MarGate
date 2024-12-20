using MarGate.Basket.Application.Handlers.Basket.Commands.UpdateBasket;
using MarGate.Campaign.Application.Handlers.Campaigns.Commands.CreateCampaign;
using MarGate.Campaign.Application.Handlers.Campaigns.Commands.DeleteCampaign;
using MarGate.Campaign.Application.Handlers.Campaigns.Queries.GetAllCampaigns;
using MarGate.Campaign.Application.Handlers.Campaigns.Queries.GetCampaignById;
using MarGate.Core.Api.Controllers;
using MarGate.Core.Api.Responses.Results;
using MarGate.Core.CQRS.Processor;
using Microsoft.AspNetCore.Mvc;

namespace MarGate.Campaign.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CampaignsController(ICQRSProcessor cqrsProcessor) : BaseController
{
    private readonly ICQRSProcessor _cqrsProcessor = cqrsProcessor;

    /// <summary>
    /// Get all campaigns
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>A list of all campaigns</returns>
    [HttpGet]
    public async Task<Result<List<GetAllCampaignsQueryResponse>>> GetAllCampaigns(CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetAllCampaignsQueryRequest(), cancellationToken);
        return new Result<List<GetAllCampaignsQueryResponse>>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Get a campaign by its ID
    /// </summary>
    /// <param name="id">The ID of the campaign</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The campaign matching the given ID</returns>
    [HttpGet("{id}")]
    public async Task<Result<GetCampaignByIdQueryResponse>> GetCampaignById(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetCampaignByIdQueryRequest { Id = id }, cancellationToken);
        return new Result<GetCampaignByIdQueryResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Create a new campaign
    /// </summary>
    /// <param name="request">The details of the campaign to be created</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after creating the campaign</returns>
    [HttpPost]
    public async Task<Result<CreateCampaignCommandResponse>> CreateCampaign(
        [FromBody] CreateCampaignRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new CreateCampaignCommandRequest
        {
            Name = request.Name,
            Description = request.Description,
            DiscountPercentage = request.DiscountPercentage,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            IsActive = request.IsActive
        }, cancellationToken);
        return new Result<CreateCampaignCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Update an existing basket
    /// </summary>
    /// <param name="id">The ID of the basket to update</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after updating the basket</returns>
    [HttpPut("{id}")]
    public async Task<Result<UpdateBasketCommandResponse>> UpdateBasket(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new UpdateBasketCommandRequest { Id = id }, cancellationToken);
        return new Result<UpdateBasketCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Delete a campaign by ID
    /// </summary>
    /// <param name="id">The ID of the campaign to delete</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after deleting the campaign</returns>
    [HttpDelete("{id}")]
    public async Task<Result<DeleteCampaignCommandResponse>> DeleteCampaign(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new DeleteCampaignCommandRequest { Id = id }, cancellationToken);
        return new Result<DeleteCampaignCommandResponse>(ResultStatus.Success, response);
    }
}
