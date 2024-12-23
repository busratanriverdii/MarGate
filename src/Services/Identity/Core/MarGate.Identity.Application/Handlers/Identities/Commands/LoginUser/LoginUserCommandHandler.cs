using MarGate.Core.Common.Exception;
using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;
using MarGate.Identity.Application.Authentication;
using MarGate.Identity.Domain.Entities;

namespace MarGate.Identity.Application.Handlers.Identities.Commands.LoginUser;

public class LoginUserCommandHandler(IUnitOfWork unitOfWork, ITokenGenerator tokenGenerator) : CommandHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IWriteRepository<User> _userWriteRepository = unitOfWork.GetWriteRepository<User>();

    public async override Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository
            .FirstOrDefaultAsync(x => x.EmailAddress.ToString() == request.EmailAddress, cancellationToken)
            ?? throw new BusinessException("User not registered", "001"); //tostring dedim Emailadress bir class oldugu için


        if (!user.PasswordText.Equals(request.PasswordText))
        {
            throw new BusinessException("Invalid password", "002");
        }

        var user = await _userWriteRepository.GetQuery()
            .Where(u => u.Emails.Any(a => a.IsActiveEmailAddress && a.EmailAddress == request.EmailAddress)
                        && u.Passwords.Any(v => v.IsActivePassword && v.PasswordText == request.PasswordText.Md5Encryption()
            .FirstOrDefaultAsync(cancellationToken); 

        var token = tokenGenerator.GenerateAccessToken(user.Id);

        return new LoginUserCommandResponse
        {
            IsSuccess = true,
            UserId = user.Id,
            Token = token // response da dönmeli...
        };
    }
}
