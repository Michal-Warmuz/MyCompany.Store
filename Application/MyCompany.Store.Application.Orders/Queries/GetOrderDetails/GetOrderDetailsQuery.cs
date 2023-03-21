using Mediator.Queries;

namespace MyCompany.Store.Application.Orders.Queries.GetOrderDetails
{
    public record GetOrderDetailsQuery : IQuery
    {
        public long OrderId { get; init; }

        public GetOrderDetailsQuery(long orderId)
        {
            OrderId = orderId;
        }
    }
}
