namespace MarGate.Order.Application.RemoteCall.Responses;

public class GetUserByIdResponse
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
