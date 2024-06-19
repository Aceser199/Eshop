using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Categories, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);


internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    //private readonly IProductRepository _productRepository;

    //public CreateProductHandler(IProductRepository productRepository)
    //{
    //    _productRepository = productRepository;
    //}

    //public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    //{
    //    var product = new Product
    //    {
    //        Name = request.Name,
    //        Categories = request.Categories,
    //        Description = request.Description,
    //        ImageFile = request.ImageFile,
    //        Price = request.Price
    //    };

    //    await _productRepository.AddProductAsync(product, cancellationToken);

    //    return product.Id;
    //}
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Categories = command.Categories,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        //await _productRepository.AddProductAsync(product, cancellationToken);

        //return new CreateProductResult(product.Id);
        return new CreateProductResult(new Guid());
    }
}
