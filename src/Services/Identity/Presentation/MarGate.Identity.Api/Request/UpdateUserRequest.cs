namespace MarGate.Identity.Api.Request
{
    public class UpdateUserRequest
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
}
