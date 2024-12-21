using MarGate.Core.CQRS.Command;
using MarGate.Identity.Domain.Entities;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.CreateUser;

public class CreateUserCommandRequest : Command<CreateUserCommandResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string AddressStreet { get; set; }
    public string AddressCity { get; set; }
    public string AddressCountry { get; set; } 
    public string EmailAddress { get; set; }
    public string PasswordText { get; set; }
}
