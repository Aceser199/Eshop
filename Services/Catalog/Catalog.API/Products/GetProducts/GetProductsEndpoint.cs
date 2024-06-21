namespace Catalog.API.Products.GetProducts;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
public record class GetProductResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetProductsQuery>();
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
