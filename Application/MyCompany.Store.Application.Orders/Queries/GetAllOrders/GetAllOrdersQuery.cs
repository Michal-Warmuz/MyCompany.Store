using Mediator.Queries;
using MyCompany.Store.Application.Orders.Enums;
using MyCompany.Store.Infrastructure.Web.Essentials.Queries;

namespace MyCompany.Store.Application.Orders.Queries.GetAllOrders
{
    public record GetAllOrdersQuery : IQuery, IPagedQuery
    {
        public int Page { get; init; }
        public int PerPage { get; init; }
        public DateTime? CreatedDate { get; init; }
        public OrderStatus? Status { get; init; }

        public GetAllOrdersQuery(int page, int perPage, DateTime? createdDate, OrderStatus? status)
        {
            Page = page;
            PerPage = perPage;
            CreatedDate = createdDate;
            Status = status;
        }
    }
}
