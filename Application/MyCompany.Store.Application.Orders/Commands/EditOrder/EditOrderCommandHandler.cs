using FluentValidation;
using Mediator.Commands;
using MyCompany.Store.Application.Shared.Commands;
using MyCompany.Store.Application.Shared.Enums;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using MyCompany.Store.Core.Domain.SeedWork;
using MyCompany.Store.Infrastructure.Database.SeedWork;

namespace MyCompany.Store.Application.Orders.Commands.EditOrder
{
    internal class EditOrderCommandHandler : ICommandHandler<EditOrderCommand, CommandResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IValidator<EditOrderCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public EditOrderCommandHandler(IOrderRepository orderRepository, IValidator<EditOrderCommand> validator, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> Handle(EditOrderCommand command, CancellationToken cancellation)
        {

            var resultValidator = _validator.Validate(command);

            if (!resultValidator.IsValid)
                return new CommandResult(ResponseStatus.ValidationErrors, string.Join(',', resultValidator.Errors));

            var order = await _orderRepository.GetAsync(new OrderId(command.OrderId));

            if(order == null)
            {
                order = Order.CreateNew(Information.CreateNew(command.AdditionalInfo), Client.CreateNew(command.ClientName));

                foreach (var orderLine in command.OrderLines)
                {
                    order.AddOrderLine(new Amount(orderLine.Price), new Product(orderLine.ProductName));
                }

                await _orderRepository.AddAsync(order);

            }

            OrderStatus? status = OrderStatus.GetOrderStatus(command.Status);

            if(status == null)
            {
                return new CommandResult(ResponseStatus.ValidationErrors, "Error status");
            }

            try
            {
                order.Edit(Information.CreateNew(command.AdditionalInfo), Client.CreateNew(command.ClientName), status);
            }
            catch(BusinessRuleValidationException ex)
            {
                return new CommandResult(ResponseStatus.ValidationErrors, ex.Message);
            }


            await _orderRepository.UpdateAsync(order);

            await _unitOfWork.CommitAsync();

            return new CommandResult(ResponseStatus.Ok);
        }
    }
}
