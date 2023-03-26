using Mediator.Queries;
using MyCompany.Store.Application.Orders.Queries.GetAllOrders.Dtos;
using MyCompany.Store.Core.Domain.Orders;
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
            OrderStatus status = null;

            switch (query.Status)
            {
                case Enums.OrderStatus.Delivery: status = OrderStatus.Delivery; break;
                case Enums.OrderStatus.Confirm: status = OrderStatus.Confirm; break;
                case Enums.OrderStatus.Cancel: status = OrderStatus.Cancel; break;
                case Enums.OrderStatus.New: status = OrderStatus.New; break;
                default:
                    break;
            }

            var orders = await _orderRepository.GetAllAsync(query.Page, query.PerPage, query.CreatedDate, status,
                order => new GetAllOrdersDto()
                {
                    OrderId = order.Id.Value,
                    Status = order.GetOrderStatus(),
                    AdditionalInfo = order.GetAdditionalInfo(),
                    ClientName = order.GetClientName(),
                    CreatedDate = order.GetCreatedDate(),
                    TotalPrice = order.GetOrderPirce()
                });

            var recordsCount = await _orderRepository.GetRecordsCountAsync();

            return new QueryResult<IEnumerable<GetAllOrdersDto>> (ResponseStatus.Ok, orders, count: recordsCount);
        }
    }
}
