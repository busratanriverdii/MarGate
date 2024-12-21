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

    public User(
        string firstName,
        string lastName,
        PhoneNumber phoneNumber,
        Address address,
        EmailAddress emailAddress,
        DateTime birthDate,
        string passwordText,
        decimal balance)
    {
        GuardAgainstInvalidUserArguments(firstName, lastName, phoneNumber, address, emailAddress, passwordText);

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
        GuardAgainstInvalidFirstName(firstName);
        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        GuardAgainstInvalidLastName(lastName);
        LastName = lastName;
    }

    public void SetPhoneNumber(PhoneNumber phoneNumber)
    {
        GuardAgainstNullPhoneNumber(phoneNumber);
        PhoneNumber = phoneNumber;
    }

    public void SetAddress(Address address)
    {
        GuardAgainstNullAddress(address);
        Address = address;
    }

    public void SetEmailAddress(EmailAddress emailAddress)
    {
        GuardAgainstNullEmailAddress(emailAddress);
        EmailAddress = emailAddress;
    }

    public void SetBirthDate(DateTime birthDate)
    {
        BirthDate = birthDate;
    }

    public void SetPasswordText(string passwordText)
    {
        GuardAgainstInvalidPassword(passwordText);
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

    private void GuardAgainstInvalidUserArguments(
        string firstName,
        string lastName,
        PhoneNumber phoneNumber,
        Address address,
        EmailAddress emailAddress,
        string passwordText)
    {
        GuardAgainstInvalidFirstName(firstName);
        GuardAgainstInvalidLastName(lastName);
        GuardAgainstNullPhoneNumber(phoneNumber);
        GuardAgainstNullAddress(address);
        GuardAgainstNullEmailAddress(emailAddress);
        GuardAgainstInvalidPassword(passwordText);
    }

    private void GuardAgainstInvalidFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException($"First name cannot be empty. Attempted to set to: {firstName}");
    }

    private void GuardAgainstInvalidLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException($"Last name cannot be empty. Attempted to set to: {lastName}");
    }

    private void GuardAgainstNullPhoneNumber(PhoneNumber phoneNumber)
    {
        if (phoneNumber == null)
            throw new ArgumentException("Phone number cannot be null.");
    }

    private void GuardAgainstNullAddress(Address address)
    {
        if (address == null)
            throw new ArgumentException("Address cannot be null.");
    }

    private void GuardAgainstNullEmailAddress(EmailAddress emailAddress)
    {
        if (emailAddress == null)
            throw new ArgumentException("Email address cannot be null.");
    }

    private void GuardAgainstInvalidPassword(string passwordText)
    {
        if (string.IsNullOrWhiteSpace(passwordText) || passwordText.Length < 6)
            throw new ArgumentException($"Password must be at least 6 characters long. Attempted to set to: {passwordText}");
    }
}

public class PhoneNumber
{
    public string Number { get; protected set; }

    public PhoneNumber(string number)
    {
        GuardAgainstInvalidPhoneNumber(number);
        Number = number;
    }

    private void GuardAgainstInvalidPhoneNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            throw new ArgumentException($"Phone number cannot be empty. Attempted to set to: {number}.");
        }
    }
}

public class EmailAddress
{
    public string Address { get; protected set; }

    public EmailAddress(string address)
    {
        GuardAgainstInvalidEmailAddress(address);
        Address = address;
    }

    private void GuardAgainstInvalidEmailAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !address.Contains('@'))
        {
            throw new ArgumentException($"Invalid email address. Attempted to set to: {address}.");
        }
    }
}

public class Address
{
    public string Street { get; protected set; }
    public string City { get; protected set; }
    public string Country { get; protected set; }

    public Address(string street, string city, string country)
    {
        GuardAgainstInvalidAddress(street, city, country);
        Street = street;
        City = city;
        Country = country;
    }

    private void GuardAgainstInvalidAddress(string street, string city, string country)
    {
        if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException($"Address cannot be empty. Attempted to set: {street}, {city}, {country}.");
        }
    }
}
