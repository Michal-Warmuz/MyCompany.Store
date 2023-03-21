using FluentValidation;

namespace MyCompany.Store.Application.Orders.Commands.EditOrder
{
    public class EditOrderCommandValidator : AbstractValidator<EditOrderCommand>
    {
        public EditOrderCommandValidator()
        {
            RuleFor(x => x.ClientName)
                .NotEmpty().NotNull().WithMessage("ClientName is required");

            RuleFor(x => x.AdditionalInfo)
                .NotEmpty().NotNull().WithMessage("AdditionalInfo is required");

            RuleFor(x => x.Status)
                .NotNull().WithMessage("Status is required");
        }
    }
}
