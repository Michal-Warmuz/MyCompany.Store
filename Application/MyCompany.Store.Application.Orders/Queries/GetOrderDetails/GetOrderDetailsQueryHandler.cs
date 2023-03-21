using Mediator.Queries;
using MyCompany.Store.Application.Orders.Queries.GetOrderDetails.Dtos;
using MyCompany.Store.Core.Domain.Orders;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using MyCompany.Store.Infrastructure.Web.Essentials.Enums;
using MyCompany.Store.Infrastructure.Web.Essentials.Queries;

namespace MyCompany.Store.Application.Orders.Queries.GetOrderDetails
{
    internal class GetOrderDetailsQueryHandler : IQueryHandler<GetOrderDetailsQuery, QueryResult<GetOrderDetailsDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderDetailsQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<QueryResult<GetOrderDetailsDto>> Handle(GetOrderDetailsQuery query, CancellationToken cancellation)
        {
            var order = await _orderRepository.GetAsync(new OrderId(query.OrderId));

            var result = new GetOrderDetailsDto()
            {
                Status = order.GetOrderStatus(),
                AdditionalInfo = order.GetAdditionalInfo(),
                ClientName = order.GetClientName(),
                CreatedDate = order.GetCreatedDate(),
                OrderLines = order.OrderLines.Select(x=> new GetOrderLineDetailsDto()
                {
                    Price = x.GetPriceValue(),
                    ProductName = x.GetProductName(),
                }),
                TotalPrice = order.GetOrderPirce()
            };

            return new QueryResult<GetOrderDetailsDto>(ResponseStatus.Ok, result);
        }
    }
}
