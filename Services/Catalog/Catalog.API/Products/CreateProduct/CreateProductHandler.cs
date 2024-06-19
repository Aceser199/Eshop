using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Categories, string Description, string ImageFile, decimal Price)
    : IRequest<CreateProductResult>;

public record CreateProductResult(Guid Id);


internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
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

    Task<CreateProductResult> IRequestHandler<CreateProductCommand, CreateProductResult>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Business logic to create a product
        throw new NotImplementedException();
    }
}
