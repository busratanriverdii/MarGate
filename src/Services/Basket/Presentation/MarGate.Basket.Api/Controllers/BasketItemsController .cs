using MarGate.Basket.Application.Handlers.BasketItem.Commands.CreateBasketItem;
using MarGate.Basket.Application.Handlers.BasketItem.Commands.DeleteBasketItem;
using MarGate.Basket.Application.Handlers.BasketItem.Commands.UpdateBasketItem;
using MarGate.Basket.Application.Handlers.BasketItem.Queries.GetAllBasketItems;
using MarGate.Basket.Application.Handlers.BasketItem.Queries.GetBasketItemById;
using MarGate.Core.Api.Controllers;
using MarGate.Core.CQRS.Processor;
using Microsoft.AspNetCore.Mvc;

namespace MarGate.Basket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketItemsController : BaseController
{
    private readonly ICQRSProcessor _cqrsProcessor;

    public BasketItemsController(ICQRSProcessor cqrsProcessor)
    {
        _cqrsProcessor = cqrsProcessor;
    }

    /// <summary>
    /// Get all basket items
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>A list of basket items</returns>
    [HttpGet]
    public async Task<Result<List<GetAllBasketItemsQueryResponse>>> GetAllBasketItems(CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetAllBasketItemsQueryRequest(), cancellationToken);
        return new Result<List<GetAllBasketItemsQueryResponse>>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Get a basket item by ID
    /// </summary>
    /// <param name="id">The ID of the basket item</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The basket item matching the given ID</returns>
    [HttpGet("{id}")]
    public async Task<Result<GetBasketItemByIdQueryResponse>> GetBasketItemById(
        [FromRoute] long id, 
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetBasketItemByIdQueryRequest { Id = id }, cancellationToken);
        return new Result<GetBasketItemByIdQueryResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Create a new basket item
    /// </summary>
    /// <param name="request">The details of the basket item to be created</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after creating the basket item</returns>
    [HttpPost]
    public async Task<Result<CreateBasketItemCommandResponse>> CreateBasketItem(
        [FromBody] CreateBasketItemRequest request, 
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new CreateBasketItemCommandRequest { ProductId = request.ProductId, BasketId = request.BasketId }, cancellationToken);
        return new Result<CreateBasketItemCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Update an existing basket item
    /// </summary>
    /// <param name="id">The ID of the basket item to update</param>
    /// <param name="request">The updated details of the basket item</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after updating the basket item</returns>
    [HttpPut("{id}")]
    public async Task<Result<UpdateBasketItemCommandResponse>> UpdateBasketItem(
        [FromRoute] long id, 
        [FromBody] UpdateBasketItemRequest request, 
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new UpdateBasketItemCommandRequest { Id = id }, cancellationToken);
        return new Result<UpdateBasketItemCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Delete a basket item by ID
    /// </summary>
    /// <param name="id">The ID of the basket item to delete</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after deleting the basket item</returns>
    [HttpDelete("{id}")]
    public async Task<Result<DeleteBasketItemCommandResponse>> DeleteBasketItem(
        [FromRoute] long id, 
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new DeleteBasketItemCommandRequest { Id = id }, cancellationToken);
        return new Result<DeleteBasketItemCommandResponse>(ResultStatus.Success, response);
    }
}
