using MarGate.Core.Api.Controllers;
using MarGate.Core.Api.Responses.Results;
using MarGate.Core.CQRS.Processor;
using MarGate.Order.Application.Handlers.Order.Commands.CreateOrder;
using MarGate.Order.Application.Handlers.Order.Commands.DeleteOrder;
using MarGate.Order.Application.Handlers.Order.Commands.UpdateOrder;
using MarGate.Order.Application.Handlers.Order.Queries.GetAllOrders;
using MarGate.Order.Application.Handlers.Order.Queries.GetOrderById;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(ICQRSProcessor cqrsProcessor) : BaseController
{
    private readonly ICQRSProcessor _cqrsProcessor = cqrsProcessor;

    /// <summary>
    /// Get all orders
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>A list of all orders</returns>
    [HttpGet]
    public async Task<Result<List<GetAllOrdersQueryResponse>>> GetAllOrders(CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetAllOrdersQueryRequest(), cancellationToken);
        return new Result<List<GetAllOrdersQueryResponse>>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Get an order by its ID
    /// </summary>
    /// <param name="id">The ID of the order</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The order matching the given ID</returns>
    [HttpGet("{id}")]
    public async Task<Result<GetOrderByIdQueryResponse>> GetOrderById(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetOrderByIdQueryRequest { Id = id }, cancellationToken);
        return new Result<GetOrderByIdQueryResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Create a new order
    /// </summary>
    /// <param name="request">The details of the order to be created</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after creating the order</returns>
    [HttpPost]
    public async Task<Result<CreateOrderCommandResponse>> CreateOrder(
        [FromBody] CreateOrderRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new CreateOrderCommandRequest
        {
            Description = request.Description,
            Address = request.Address,
            UserId = request.UserId
        }, cancellationToken);

        return new Result<CreateOrderCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Update an existing order
    /// </summary>
    /// <param name="id">The ID of the order to update</param>
    /// <param name="request">The updated details of the order</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after updating the order</returns>
    [HttpPut("{id}")]
    public async Task<Result<UpdateOrderCommandResponse>> UpdateOrder(
        [FromRoute] long id,
        [FromBody] UpdateOrderRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new UpdateOrderCommandRequest
        {
            Id = id,
            Description = request.Description,
            Address = request.Address
        }, cancellationToken);

        return new Result<UpdateOrderCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Delete an order by ID
    /// </summary>
    /// <param name="id">The ID of the order to delete</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after deleting the order</returns>
    [HttpDelete("{id}")]
    public async Task<Result<DeleteOrderCommandResponse>> DeleteOrder(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new DeleteOrderCommandRequest { Id = id }, cancellationToken);
        return new Result<DeleteOrderCommandResponse>(ResultStatus.Success, response);
    }
}
