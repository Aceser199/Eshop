namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string CardHolderName { get; } = default!;
    public string CardNumber { get; } = default!;
    public string Expiration { get; } = default!;
    public string CVV { get; } = default!;
    public int PaymentMethod { get; } = default!;

    protected Payment() { }

    private Payment(string cardHolderName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string cardHolderName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardHolderName, nameof(cardHolderName));
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber, nameof(cardNumber));
        //ArgumentException.ThrowIfNullOrWhiteSpace(expiration, nameof(expiration));
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv, nameof(cvv));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3, nameof(cvv));
        //ArgumentOutOfRangeException.ThrowIfLessThan(paymentMethod, 0, nameof(paymentMethod));

        return new Payment(cardHolderName, cardNumber, expiration, cvv, paymentMethod);
    }
}
