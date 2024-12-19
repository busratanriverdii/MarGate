using MarGate.Core.DDD;

namespace MarGate.Identity.Domain.Entities;
public class User : BaseEntity
{
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public PhoneNumber PhoneNumber { get; protected set; }
    public Address Address { get; protected set; }
    public EmailAddress EmailAddress { get; protected set; }
    public DateTime BirthDate { get; protected set; }
    public string PasswordText { get; protected set; }
    public decimal Balance { get; protected set; }

    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException($"First name cannot be empty. Attempted to set to: {firstName}.");
        }

        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException($"Last name cannot be empty. Attempted to set to: {lastName}.");
        }

        LastName = lastName;
    }

    public void SetPhoneNumber(PhoneNumber phoneNumber)
    {
        PhoneNumber = phoneNumber ??
            throw new ArgumentException($"Phone number cannot be null.");
    }

    public void SetAddress(Address address)
    {
        Address = address ??
            throw new ArgumentException($"Address cannot be null.");
    }

    public void SetEmailAddress(EmailAddress emailAddress)
    {
        EmailAddress = emailAddress ??
            throw new ArgumentException($"Email address cannot be null.");
    }

    public void SetBirthDate(DateTime birthDate)
    {
        BirthDate = birthDate;
    }

    public void SetPasswordText(string passwordText)
    {
        if (string.IsNullOrWhiteSpace(passwordText) || passwordText.Length < 6)
        {
            throw new ArgumentException($"Password must be at least 6 characters long. Attempted to set to: {passwordText}.");
        }

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

public class PhoneNumber
{
    public string Number { get; protected set; }

    public PhoneNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            throw new ArgumentException($"Phone number cannot be empty. Attempted to set to: {number}.");
        }

        Number = number;
    }
}

public class EmailAddress
{
    public string Address { get; protected set; }

    public EmailAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !address.Contains('@'))
        {
            throw new ArgumentException($"Invalid email address. Attempted to set to: {address}.");
        }

        Address = address;
    }
}

public class Address
{
    public string Street { get; protected set; }
    public string City { get; protected set; }
    public string Country { get; protected set; }

    public Address(string street, string city, string country)
    {
        if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException($"Address cannot be empty. Attempted to set: {street}, {city}, {country}.");
        }

        Street = street;
        City = city;
        Country = country;
    }
}
