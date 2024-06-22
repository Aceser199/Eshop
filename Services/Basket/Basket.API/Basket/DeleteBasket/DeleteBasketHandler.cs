using FluentValidation;

namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string Username) : ICommand<DeleteBasketResult>;
public record DeleteBasketResult(bool IsDeleted);

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
    }
}

public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    private readonly IBasketRepository _repository;

    public DeleteBasketHandler(IBasketRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        //var isDeleted = await _repository.DeleteBasketAsync(command.Username);
        //return new DeleteBasketResult(isDeleted);

        return new DeleteBasketResult(true);
    }
}
