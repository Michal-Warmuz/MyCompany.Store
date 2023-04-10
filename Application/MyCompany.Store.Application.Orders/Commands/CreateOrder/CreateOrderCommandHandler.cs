using FluentValidation;
using Mediator.Commands;
using MyCompany.Store.Application.Shared.Exceptions;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using MyCompany.Store.Infrastructure.Database.SeedWork;

namespace MyCompany.Store.Application.Orders.Commands.CreateOrder
{
    internal class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IValidator<CreateOrderCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IValidator<CreateOrderCommand> validator, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateOrderCommand command, CancellationToken cancellation)
        {

            var resultValidator = _validator.Validate(command);

            if (!resultValidator.IsValid)
                throw new InvalidCommandException($"Invalid: {string.Join(',', resultValidator.Errors)}");

            var order = Order.CreateNew(Information.CreateNew(command.AdditionalInfo), Client.CreateNew(command.ClientName));

            foreach (var orderLine in command.OrderLines)
            {
                order.AddOrderLine(amount: new Amount(orderLine.Price), product: new Product(orderLine.ProductName));
            }

            await _orderRepository.AddAsync(order);

            await _unitOfWork.CommitAsync();
        }
    }
}
