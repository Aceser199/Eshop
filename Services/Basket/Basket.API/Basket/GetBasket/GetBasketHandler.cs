namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string Username) : IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart Cart);

internal class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    private readonly IBasketRepository _repository;

    public GetBasketQueryHandler(IBasketRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        //var basket = await _repository.GetBasketAsync(query.Username);
        //return new GetBasketResult(basket ?? new ShoppingCart(query.Username));

        // TOdo : Implement the logic to get the basket from the repository


        return new GetBasketResult(new ShoppingCart("swn"));
    }
}
