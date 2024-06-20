namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductResponse(bool IsSuccess);

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new DeleteProductCommand(id);
            var result = await sender.Send(command, cancellationToken);

            var response = result.Adapt<DeleteProductResponse>();

            return Results.Ok(response);
        }).WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(statusCode: StatusCodes.Status404NotFound)
        .ProducesProblem(statusCode: StatusCodes.Status400BadRequest)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}