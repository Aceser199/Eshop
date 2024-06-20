namespace Catalog.API.Products.GetProductById;

//public record GetProductByIdRequest(Guid Id)
public record GetProductByIdResponse(Product? Product);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            //var query = request.Adapt<GetProductByIdQuery>();
            var query = new GetProductByIdQuery(id);
            var result = await sender.Send(query, default);

            var response = result.Adapt<GetProductByIdResponse>();

            return Results.Ok(response);
        }).WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(statusCode: StatusCodes.Status404NotFound)
        .WithSummary("Get Product by Id")
        .WithDescription("Get Product by Id");
    }
}
