using FluentValidation;
using Mediator.Commands;
using MyCompany.Store.Application.Shared.Exceptions;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using MyCompany.Store.Infrastructure.Database.SeedWork;

namespace MyCompany.Store.Application.Orders.Commands.EditOrder
{
    internal class EditOrderCommandHandler : ICommandHandler<EditOrderCommand>
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

        public async Task Handle(EditOrderCommand command, CancellationToken cancellation)
        {

            var resultValidator = _validator.Validate(command);

            if (!resultValidator.IsValid)
                throw new InvalidCommandException($"Invalid: {string.Join(',', resultValidator.Errors)}");

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
                throw new InvalidCommandException("Error Status");

            order.Edit(Information.CreateNew(command.AdditionalInfo), Client.CreateNew(command.ClientName), status);


            await _orderRepository.UpdateAsync(order);

            await _unitOfWork.CommitAsync();
        }
    }
}
