namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string Username);

public class StoreBasketCommandvalidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandvalidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Username is required");
    }
}

public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    private readonly IBasketRepository _repository;

    public StoreBasketCommandHandler(IBasketRepository repository)
    {
        _repository = repository;
    }

    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.Cart;

        await _repository.StoreBasketAsync(cart, cancellationToken);
        return new StoreBasketResult(cart.UserName);
    }
}
