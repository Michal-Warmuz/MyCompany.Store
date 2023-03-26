using FluentValidation;
using Mediator.Commands;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using MyCompany.Store.Infrastructure.Web.Essentials.Commands;
using MyCompany.Store.Infrastructure.Web.Essentials.Enums;

namespace MyCompany.Store.Application.Orders.Commands.AddOrderLine
{
    public class AddOrderLineCommandHandler : ICommandHandler<AddOrderLineCommand, CommandResult>
    {
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IValidator<AddOrderLineCommand> _validator;
        private readonly IOrderRepository _orderRepository;

        public AddOrderLineCommandHandler(IOrderLineRepository orderLineRepository, IValidator<AddOrderLineCommand> validator, IOrderRepository orderRepository)
        {
            _orderLineRepository = orderLineRepository;
            _validator = validator;
            _orderRepository = orderRepository;
        }

        public async Task<CommandResult> Handle(AddOrderLineCommand command, CancellationToken cancellation)
        {
            var resultValidator = _validator.Validate(command);

            if (!resultValidator.IsValid)
                return new CommandResult(ResponseStatus.ValidationErrors, string.Join(',', resultValidator.Errors));

            var order = await _orderRepository.GetAsync(new OrderId(command.OrderId));

            if (order == null)
                return new CommandResult(ResponseStatus.NotFound, "Nie znaleziono zamówiównia o takim numerze ID");

            var orderLine = OrderLine.CreateNew(new OrderId(command.OrderId), new Amount(command.Price), new Product(command.ProductName));

            await _orderLineRepository.AddAsync(orderLine);

            await _orderLineRepository.CommitAsync();

            return new CommandResult(ResponseStatus.Created);
        }
    }
}
