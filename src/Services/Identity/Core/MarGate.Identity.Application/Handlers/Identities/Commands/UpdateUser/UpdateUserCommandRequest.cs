using MarGate.Core.CQRS.Command;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.UpdateUser;

public class UpdateUserCommandRequest : Command<UpdateUserCommandResponse>
{
    public long Id { get; set; }
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
