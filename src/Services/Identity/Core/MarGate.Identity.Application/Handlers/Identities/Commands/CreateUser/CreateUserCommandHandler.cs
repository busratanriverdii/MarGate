using MarGate.Core.CQRS.Command;
using MarGate.Identity.Domain.Entities;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;
using MarGate.Identity.Application.Extensions;
using MarGate.Core.Common.Exception;
using MarGate.Identity.Application.Authentication;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.CreateUser;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork, ITokenGenerator generator) : CommandHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IWriteRepository<User> _userWriteRepository = unitOfWork.GetWriteRepository<User>();

    public async override Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var isExist = await _userWriteRepository.AnyAsync(x => x.EmailAddress == request.EmailAddress, cancellationToken);
        if (isExist)
        {
            throw new BusinessException("user already exist.", "004");
        }

        var user = new User(
        request.FirstName,
        request.LastName,
        request.PhoneNumber,
        request.Address,
        request.EmailAddress,
        request.BirthDate,
        request.PasswordText.Md5Encryption(),
        0m
    );

        _userWriteRepository.Create(user);

        var token = generator.GenerateAccessToken(user.Id);

        return new CreateUserCommandResponse()
        {
            IsSuccess = true,
            UserId = user.Id,
            Token = token
        };

    }
}
