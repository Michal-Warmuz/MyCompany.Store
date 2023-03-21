using Mediator.Queries;
using MyCompany.Store.Application.Orders.Queries.GetAllOrders.Dtos;
using MyCompany.Store.Core.Domain.Orders.Contracts;
using MyCompany.Store.Infrastructure.Web.Essentials.Enums;
using MyCompany.Store.Infrastructure.Web.Essentials.Queries;

namespace MyCompany.Store.Application.Orders.Queries.GetAllOrders
{
    internal class GetAllOrdersQueryHandler : IQueryHandler<GetAllOrdersQuery, QueryResult<IEnumerable<GetAllOrdersDto>>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<QueryResult<IEnumerable<GetAllOrdersDto>>> Handle(GetAllOrdersQuery query, CancellationToken cancellation)
        {
            var orders = await _orderRepository.GetAllAsync();

            var result = orders.Select(order => new GetAllOrdersDto()
            {
                Status = order.GetOrderStatus(),
                AdditionalInfo = order.GetAdditionalInfo(),
                ClientName = order.GetClientName(),
                CreatedDate = order.GetCreatedDate(),
                OrderLines = order.OrderLines.Select(x => new GetAllOrderLinesDto()
                {
                    Price = x.GetPriceValue(),
                    ProductName = x.GetProductName(),
                }),
                TotalPrice = order.GetOrderPirce()
            });

            return new QueryResult<IEnumerable<GetAllOrdersDto>> (ResponseStatus.Ok, result);
        }
    }
}
