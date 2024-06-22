using Basket.API.Basket.StoreBasket;

namespace Basket.API.Basket.DeleteBasket;

//public record DeleteBasketRequest(string Username);
public record DeleteBasketResponse(bool IsDeleted);

public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{username}", async (string username, ISender sender) =>
        {
            var command = new DeleteBasketCommand(username);
            var result = await sender.Send(command, default);

            var response = result.Adapt<DeleteBasketResponse>();

            return Results.Ok(response);
        }).WithName("DeleteBasket")
        .Produces<StoreBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(statusCode: StatusCodes.Status400BadRequest)
        .ProducesProblem(statusCode: StatusCodes.Status404NotFound)
        .WithSummary("Delete Basket")
        .WithDescription("Delete basket");
    }
}
