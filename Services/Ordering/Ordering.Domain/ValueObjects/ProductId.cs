namespace Ordering.Domain.ValueObjects;

public record ProductId
{
    public Guid Value { get; }

    private ProductId(Guid value) => Value = value;

    private static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        if (value == Guid.Empty)
        {
            throw new DomainException($"{nameof(ProductId)} cannot be empty");
        }

        return new ProductId(value);
    }
}
