using MarGate.Core.CQRS.Command;

namespace MarGate.Identity.Application.Handlers.Identities.Commands.LoginUser;

public class LoginUserCommandRequest : Command<LoginUserCommandResponse>
{
    public string EmailAddress { get; set; }
    public string PasswordText { get; set; }
}
