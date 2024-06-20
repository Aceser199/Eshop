namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductResponse(bool IsSuccess);

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            try
            {
                var command = new DeleteProductCommand(id);
                var result = await sender.Send(command, cancellationToken);

                var response = result.Adapt<DeleteProductResponse>();

                return Results.Ok(response);
            }
            catch (ProductNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (Exception)
            {
                return Results.BadRequest("Something went wrong.");
                //return Results.Problem(ex.Message, StatusCodes.Status400BadRequest);
            }
        }).WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(statusCode: StatusCodes.Status404NotFound)
        .ProducesProblem(statusCode: StatusCodes.Status400BadRequest)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}