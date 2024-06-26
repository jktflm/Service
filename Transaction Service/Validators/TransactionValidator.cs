using FluentValidation;
using Transaction_Service.Models;

public class TransactionValidator : AbstractValidator<Transactions>
{
    public TransactionValidator()
    {
        RuleFor(x => x.ReferenceNumber).NotEmpty().MaximumLength(20).Matches("^[a-zA-Z0-9]*$");
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.TransactionDate).NotEmpty();
        RuleFor(x => x.Symbol)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(5)
            .Matches("^[a-zA-Z0-9]*$");
        RuleFor(x => x.OrderSide).Must(x => x == "Buy" || x == "Sell");
        RuleFor(x => x.OrderStatus).Must(x => x == "Open" || x == "Matched" || x == "Cancelled");
    }
}