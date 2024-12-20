using MarGate.Core.Api.Controllers;
using MarGate.Core.Api.Responses.Results;
using MarGate.Core.CQRS.Processor;
using MarGate.Identity.Application.Handlers.Identity.Commands.CreateUser;
using MarGate.Identity.Application.Handlers.Identity.Commands.DeleteUser;
using MarGate.Identity.Application.Handlers.Identity.Commands.UpdateUser;
using MarGate.Identity.Application.Handlers.Identity.Queries.GetAllUsers;
using MarGate.Identity.Application.Handlers.Identity.Queries.GetUserById;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(ICQRSProcessor cqrsProcessor) : BaseController
{
    private readonly ICQRSProcessor _cqrsProcessor = cqrsProcessor;

    /// <summary>
    /// Get all users
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>A list of all users</returns>
    [HttpGet]
    public async Task<Result<List<GetAllUsersQueryResponse>>> GetAllUsers(CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetAllUsersQueryRequest(), cancellationToken);
        return new Result<List<GetAllUsersQueryResponse>>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Get a user by their ID
    /// </summary>
    /// <param name="id">The ID of the user</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The user matching the given ID</returns>
    [HttpGet("{id}")]
    public async Task<Result<GetUserByIdQueryResponse>> GetUserById(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new GetUserByIdQueryRequest { Id = id }, cancellationToken);
        return new Result<GetUserByIdQueryResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Create a new user
    /// </summary>
    /// <param name="request">The details of the user to be created</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after creating the user</returns>
    [HttpPost]
    public async Task<Result<CreateUserCommandResponse>> CreateUser(
        [FromBody] CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new CreateUserCommandRequest
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address,
            BirthDate = request.BirthDate,
            PhoneNumber = request.PhoneNumber,
            EmailAddress = request.EmailAddress,
            PasswordText = request.PasswordText
        }, cancellationToken);

        return new Result<CreateUserCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Update an existing user
    /// </summary>
    /// <param name="id">The ID of the user to update</param>
    /// <param name="request">The updated details of the user</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after updating the user</returns>
    [HttpPut("{id}")]
    public async Task<Result<UpdateUserCommandResponse>> UpdateUser(
        [FromRoute] long id,
        [FromBody] UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new UpdateUserCommandRequest
        {
            Id = id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address,
            BirthDate = request.BirthDate,
            PhoneNumber = request.PhoneNumber,
            EmailAddress = request.EmailAddress,
            PasswordText = request.PasswordText
        }, cancellationToken);

        return new Result<UpdateUserCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Delete a user by their ID
    /// </summary>
    /// <param name="id">The ID of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after deleting the user</returns>
    [HttpDelete("{id}")]
    public async Task<Result<DeleteUserCommandResponse>> DeleteUser(
        [FromRoute] long id,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new DeleteUserCommandRequest { Id = id }, cancellationToken);
        return new Result<DeleteUserCommandResponse>(ResultStatus.Success, response);
    }

    /// <summary>
    /// Update the balance of a user
    /// </summary>
    /// <param name="id">The ID of the user</param>
    /// <param name="request">The balance update details</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>The response after updating the user's balance</returns>
    [HttpPut("{id}/balance")]
    public async Task<Result<UpdateUserBalanceCommandResponse>> UpdateUserBalance(
        [FromRoute] long id,
        [FromBody] UpdateUserBalanceRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _cqrsProcessor.ProcessAsync(new UpdateUserBalanceCommandRequest
        {
            Id = id,
            Amount = request.Amount
        }, cancellationToken);

        return new Result<UpdateUserBalanceCommandResponse>(ResultStatus.Success, response);
    }
}
