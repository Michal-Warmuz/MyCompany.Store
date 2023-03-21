using FluentValidation;

namespace MyCompany.Store.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator() 
        {
            RuleFor(x => x.ClientName)
                .NotEmpty().NotNull().WithMessage("ClientName is required");

            RuleFor(x => x.AdditionalInfo)
                .NotEmpty().NotNull().WithMessage("AdditionalInfo is required");

            RuleFor(x => x.OrderLines)
                .NotEmpty().NotNull().WithMessage("OrderLines is required");
        }
    }
}
