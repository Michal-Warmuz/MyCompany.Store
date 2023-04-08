using FluentValidation;
using Mediator.Commands;
using MyCompany.Store.Application.Shared.Commands;
using MyCompany.Store.Application.Shared.Enums;
using MyCompany.Store.Core.Domain.Orders.Contracts;

namespace MyCompany.Store.Application.Orders.Commands.EditOrder
{
    internal class EditOrderCommandHandler : ICommandHandler<EditOrderCommand, CommandResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IValidator<EditOrderCommand> _validator;

        public EditOrderCommandHandler(IOrderRepository orderRepository, IValidator<EditOrderCommand> validator)
        {
            _orderRepository = orderRepository;
            _validator = validator;
        }

        public async Task<CommandResult> Handle(EditOrderCommand command, CancellationToken cancellation)
        {

            //var resultValidator = _validator.Validate(command);

            //if (!resultValidator.IsValid)
            //    return new CommandResult(ResponseStatus.ValidationErrors, string.Join(',', resultValidator.Errors));

            //var order = await _orderRepository.GetAsync(new OrderId(command.OrderId));

            //if(order == null)
            //{
            //    return new CommandResult(ResponseStatus.NotFound, "Order not found");
            //}

            //OrderStatus status = null;

            //switch (command.Status)
            //{
            //    case Enums.OrderStatus.Confirm:
            //        status = OrderStatus.Confirm;
            //        break;
            //    case Enums.OrderStatus.Delivery:
            //        status = OrderStatus.Delivery;
            //        break;
            //    case Enums.OrderStatus.Cancel:
            //        status = OrderStatus.Cancel;
            //        break;
            //    default:
            //        break;
            //}

            //try
            //{
            //    order.Edit(Information.CreateNew(command.AdditionalInfo), Client.CreateNew(command.ClientName), status);
            //}
            //catch(BusinessRuleValidationException ex)
            //{
            //    return new CommandResult(ResponseStatus.ValidationErrors, ex.Message);
            //}


            //_orderRepository.Update(order);

            //await _orderRepository.CommitAsync();

            return new CommandResult(ResponseStatus.Ok);
        }
    }
}
