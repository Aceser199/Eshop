namespace Catalog.API.Products.GetProducts;

//public record GetProductRequest();
public record class GetProductResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var query = new GetProductsQuery();
            var result = await sender.Send(query, default);

            var response = result.Adapt<GetProductResponse>();

            return Results.Ok(response);
        }).WithName("GetProducts")
        .Produces<IEnumerable<Product>>(StatusCodes.Status200OK)
        .ProducesProblem(statusCode: StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
}
