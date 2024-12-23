using MarGate.Core.DDD;

namespace MarGate.Identity.Domain.Entities;

public class User : BaseEntity
{
    public User()
    {

    }
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string PhoneNumber { get; protected set; }
    public string Address { get; protected set; }
    public string EmailAddress { get; protected set; }
    public DateTime BirthDate { get; protected set; }
    public string PasswordText { get; protected set; }
    public decimal Balance { get; protected set; }

    public User(
        string firstName,
        string lastName,
        string phoneNumber,
        string address,
        string emailAddress,
        DateTime birthDate,
        string passwordText,
        decimal balance)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Address = address;
        EmailAddress = emailAddress;
        BirthDate = birthDate;
        PasswordText = passwordText;
        Balance = balance;
    }

    public void SetFirstName(string firstName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        LastName = lastName;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber);
        PhoneNumber = phoneNumber;
    }

    public void SetAddress(string address)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(address);
        Address = address;
    }

    public void SetEmailAddress(string emailAddress)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
        EmailAddress = emailAddress;
    }

    public void SetBirthDate(DateTime birthDate)
    {
        BirthDate = birthDate;
    }

    public void SetPasswordText(string passwordText)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(passwordText);
        PasswordText = passwordText;
    }

    public void UpdateBalance(decimal amount)
    {
        if (Balance + amount < 0)
        {
            throw new InvalidOperationException($"Insufficient funds. Attempted to deduct: {amount:C}.");
        }

        Balance += amount;
    }
}
