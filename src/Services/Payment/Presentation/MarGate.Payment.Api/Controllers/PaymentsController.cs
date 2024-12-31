using MarGate.Payment.Application.Handlers.Payment.Commands.CreatePayment;
using MarGate.Payment.Application.Handlers.Payment.Commands.DeletePayment;
using MarGate.Payment.Application.Handlers.Payment.Commands.UpdatePayment;
using MarGate.Payment.Application.Handlers.Payment.Queries.GetAllPayments;
using MarGate.Payment.Application.Handlers.Payment.Queries.GetPaymentById;
using MarGate.Core.Api.Controllers;
using MarGate.Core.Api.Responses.Results;
using MarGate.Core.CQRS.Processor;
using Microsoft.AspNetCore.Mvc;

namespace MarGate.Payment.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController(ICQRSProcessor cqrsProcessor) : BaseController
{
    private readonly ICQRSProcessor _cqrsProcessor = cqrsProcessor;

    /// <summary>
    /// Get all payments
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>A list of all payments</returns>
    [HttpGet]
    public async Task<Result<List<GetAllPaymentsQueryResponse>>> GetAllPayments(CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetAllPaymentsQueryRequest(), cancellationToken);
        return new Result<List<GetAllPaymentsQueryResponse>>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Get a payment by its ID
    /// </summary>
    /// <param name="id">The ID of the payment</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The payment matching the given ID</returns>
    [HttpGet("{id}")]
    public async Task<Result<GetPaymentByIdQueryResponse>> GetPaymentById(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetPaymentByIdQueryRequest { Id = id }, cancellationToken);
        return new Result<GetPaymentByIdQueryResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Create a new payment
    /// </summary>
    /// <param name="request">The details of the payment to be created</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after creating the payment</returns>
    [HttpPost]
    public async Task<Result<CreatePaymentCommandResponse>> CreatePayment(
        [FromBody] CreatePaymentCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(request, cancellationToken);
        return new Result<CreatePaymentCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Update an existing payment
    /// </summary>
    /// <param name="id">The ID of the payment to update</param>
    /// <param name="request">The updated details of the payment</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after updating the payment</returns>
    [HttpPut("{id}")]
    public async Task<Result<UpdatePaymentCommandResponse>> UpdatePayment(
        [FromRoute] long id,
        [FromBody] UpdatePaymentCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new UpdatePaymentCommandRequest
        {
            Id = id,
            Amount = request.Amount,
            Status = request.Status
        }, cancellationToken);
        return new Result<UpdatePaymentCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Delete a payment by ID
    /// </summary>
    /// <param name="id">The ID of the payment to delete</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after deleting the payment</returns>
    [HttpDelete("{id}")]
    public async Task<Result<DeletePaymentCommandResponse>> DeletePayment(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new DeletePaymentCommandRequest { Id = id }, cancellationToken);
        return new Result<DeletePaymentCommandResponse>(ResultStatus.Success, response);
    }
}
