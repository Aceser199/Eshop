namespace Ordering.Domain.ValueObjects;

public record CustomerId
{
    public Guid Value { get; }

    private CustomerId(Guid value) => Value = value;

    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("Customer id cannot be empty");
        }

        return new CustomerId(value);
    }

    //public CustomerId(Guid value)
    //{
    //    if (value == Guid.Empty)
    //    {
    //        throw new ArgumentException("Customer id cannot be empty", nameof(value));
    //    }

    //    Value = value;
    //}

    //public static implicit operator Guid(CustomerId customerId) => customerId.Value;
}
