﻿namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductRequest(Guid Id, string Name, List<string> Categories, string Description, string ImageFile, decimal Price);

public record UpdateProductResponse(bool IsSuccess);

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = request.Adapt<UpdateProductCommand>();
            var result = await sender.Send(command, cancellationToken);

            var response = result.Adapt<UpdateProductResponse>();

            return Results.Ok(response);

        }).WithName("UpdateProduct")
        .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(statusCode: StatusCodes.Status404NotFound)
        .ProducesProblem(statusCode: StatusCodes.Status400BadRequest)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
    }
}
