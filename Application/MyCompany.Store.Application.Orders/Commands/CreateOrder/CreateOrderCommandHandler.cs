using FluentValidation;
using Mediator.Commands;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using MyCompany.Store.Infrastructure.Web.Essentials.Commands;
using MyCompany.Store.Infrastructure.Web.Essentials.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyCompany.Store.Application.Orders.Commands.CreateOrder
{
    internal class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, CommandResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IValidator<CreateOrderCommand> _validator;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IValidator<CreateOrderCommand> validator)
        {
            _orderRepository = orderRepository;
            _validator = validator;
        }

        public async Task<CommandResult> Handle(CreateOrderCommand command, CancellationToken cancellation)
        {

            var resultValidator = _validator.Validate(command);

            if (!resultValidator.IsValid)
                return new CommandResult(ResponseStatus.ValidationErrors, string.Join(',', resultValidator.Errors));

            var order = Order.CreateNew(Information.CreateNew(command.AdditionalInfo), Client.CreateNew(command.ClientName));

            foreach (var orderLine in command.OrderLines)
            {
                order.AddOrderLine(new Amount(orderLine.Price), new Product(orderLine.ProductName));
            }

            await _orderRepository.AddAsync(order);

            await _orderRepository.CommitAsync();

            return new CommandResult(ResponseStatus.Created);
        }
    }
}
