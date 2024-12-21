namespace MarGate.Identity.Application.Handlers.Identity.Queries.GetAllUsers;

public class GetAllUsersQueryResponse
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public decimal Balance { get; set; }
    public DateTime BirthDate { get; set; }
}
