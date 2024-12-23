namespace MarGate.Identity.Application.Handlers.Identities.Commands.LoginUser;

public class LoginUserCommandResponse
{
    public bool IsSuccess { get; set; }
    public long UserId { get; set; }
    public string Token { get; set; }
}
