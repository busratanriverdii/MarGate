namespace MarGate.Identity.Application.Handlers.Identity.Commands.CreateUser;

public class CreateUserCommandResponse
{
    public bool IsSuccess { get; set; }
    public long UserId { get; set; }
    public string Token { get; set; }
}
