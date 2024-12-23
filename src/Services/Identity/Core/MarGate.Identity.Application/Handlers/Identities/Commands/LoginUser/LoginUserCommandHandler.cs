using MarGate.Core.Common.Exception;
using MarGate.Core.CQRS.Command;
using MarGate.Identity.Application.Authentication;
using MarGate.Identity.Domain.Entities;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;
using MarGate.Identity.Application.Extensions;

namespace MarGate.Identity.Application.Handlers.Identities.Commands.LoginUser;

public class LoginUserCommandHandler(IUnitOfWork unitOfWork, ITokenGenerator tokenGenerator) : CommandHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IWriteRepository<User> _userWriteRepository = unitOfWork.GetWriteRepository<User>();

    public async override Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository
            .FirstOrDefaultAsync(x => x.EmailAddress.ToString() == request.EmailAddress && x.PasswordText == request.PasswordText.Md5Encryption(), cancellationToken)
            ?? throw new BusinessException("User not registered", "001");

        var token = tokenGenerator.GenerateAccessToken(user.Id);

        return new LoginUserCommandResponse
        {
            IsSuccess = true,
            UserId = user.Id,
            Token = token
        };
    }
}
