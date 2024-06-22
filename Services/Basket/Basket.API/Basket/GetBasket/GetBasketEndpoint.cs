namespace Basket.API.Basket.GetBasket;

public record GetBasketResponse(ShoppingCart Cart);

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{username}", async (string username, ISender sender) =>
        {
            var query = new GetBasketQuery(username);
            var result = await sender.Send(query, default);

            var response = result.Adapt<GetBasketResponse>();

            return Results.Ok(response);
        }).WithName("GetBasket")
    .Produces<IEnumerable<GetBasketResponse>>(StatusCodes.Status200OK)
    .ProducesProblem(statusCode: StatusCodes.Status400BadRequest)
    .WithSummary("Get Basket")
    .WithDescription("Get basket");
    }
}

//.WithMetadata("swagger:summary", "Get the basket for a user")