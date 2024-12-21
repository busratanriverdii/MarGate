using MarGate.Basket.Api.Request.Basket;
using MarGate.Basket.Application.Handlers.Basket.Commands.CreateBasket;
using MarGate.Basket.Application.Handlers.Basket.Commands.DeleteBasket;
using MarGate.Basket.Application.Handlers.Basket.Commands.UpdateBasket;
using MarGate.Basket.Application.Handlers.Basket.Queries.GetAllBaskets;
using MarGate.Basket.Application.Handlers.Basket.Queries.GetBasketById;
using MarGate.Core.Api.Controllers;
using MarGate.Core.Api.Responses.Results;
using MarGate.Core.CQRS.Processor;
using Microsoft.AspNetCore.Mvc;

namespace MarGate.Basket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController(ICQRSProcessor cqrsProcessor) : BaseController
{
    private readonly ICQRSProcessor _cqrsProcessor = cqrsProcessor;

    /// <summary>
    /// Get all baskets
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>A list of all baskets</returns>
    [HttpGet]
    public async Task<Result<List<GetAllBasketsQueryResponse>>> GetAllBaskets(CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetAllBasketsQueryRequest(), cancellationToken);
        return new Result<List<GetAllBasketsQueryResponse>>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Get a basket by its ID
    /// </summary>
    /// <param name="id">The ID of the basket</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The basket matching the given ID</returns>
    [HttpGet("{id}")]
    public async Task<Result<GetBasketByIdQueryResponse>> GetBasketById(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetBasketByIdQueryRequest { Id = id }, cancellationToken);
        return new Result<GetBasketByIdQueryResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Create a new basket
    /// </summary>
    /// <param name="request">The details of the basket to be created</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after creating the basket</returns>
    [HttpPost]
    public async Task<Result<CreateBasketCommandResponse>> CreateBasket(
        [FromBody] CreateBasketRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new CreateBasketCommandRequest { UserId = request.UserId }, cancellationToken);
        return new Result<CreateBasketCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Update an existing basket
    /// </summary>
    /// <param name="id">The ID of the basket to update</param>
    /// <param name="request">The updated details of the basket</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after updating the basket</returns>
    [HttpPut("{id}")]
    public async Task<Result<UpdateBasketCommandResponse>> UpdateBasket(
        [FromRoute] long id,
        [FromBody] UpdateBasketRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new UpdateBasketCommandRequest { Id = id }, cancellationToken);
        return new Result<UpdateBasketCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Delete a basket by ID
    /// </summary>
    /// <param name="id">The ID of the basket to delete</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after deleting the basket</returns>
    [HttpDelete("{id}")]
    public async Task<Result<DeleteBasketCommandResponse>> DeleteBasket(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new DeleteBasketCommandRequest { Id = id }, cancellationToken);
        return new Result<DeleteBasketCommandResponse>(ResultStatus.Success, response);
    }
}
