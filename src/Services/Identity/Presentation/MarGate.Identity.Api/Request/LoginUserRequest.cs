namespace MarGate.Identity.Api.Request;

public class LoginUserRequest
{
    public string EmailAddress { get; set; }
    public string PasswordText { get; set; }
}
