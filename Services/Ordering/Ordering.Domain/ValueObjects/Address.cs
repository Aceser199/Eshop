namespace Ordering.Domain.ValueObjects;

public record Address
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    public string EmailAddress { get; } = default!;
    public string AddressLine { get; } = default!;
    //public string City { get; } = default!;
    public string State { get; } = default!;
    public string Country { get; } = default!;
    public string ZipCode { get; } = default!;

    protected Address() { }

    private Address(string firstName, string lastName, string emailAddress, string addressLine, string state, string country, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        //City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string state, string country, string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName, nameof(firstName));
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName, nameof(lastName));
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress, nameof(emailAddress));
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine, nameof(addressLine));
        //ArgumentException.ThrowIfNullOrWhiteSpace(city, nameof(city));
        ArgumentException.ThrowIfNullOrWhiteSpace(state, nameof(state));
        ArgumentException.ThrowIfNullOrWhiteSpace(country, nameof(country));
        ArgumentException.ThrowIfNullOrWhiteSpace(zipCode, nameof(zipCode));

        return new Address(firstName, lastName, emailAddress, addressLine, state, country, zipCode);
    }
}
