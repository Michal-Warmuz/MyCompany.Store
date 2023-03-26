using FluentValidation;

namespace MyCompany.Store.Application.Orders.Commands.AddOrderLine
{
    public class AddOrderLineCommandValidator : AbstractValidator<AddOrderLineCommand>
    {
        public AddOrderLineCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().NotNull().WithMessage("OrderId is required");

            RuleFor(x => x.ProductName)
                .NotEmpty().NotNull().WithMessage("ProductName is required");

            RuleFor(x => x.Price)
                .NotEmpty().NotNull().WithMessage("Price is required");
        }
    }
}
