using Mediator.Queries;
using MyCompany.Store.Application.Shared.Queries;
using MyCompany.Store.Core.Domain.Orders.Enums;

namespace MyCompany.Store.Application.Orders.Queries.GetAllOrders
{
    public record GetAllOrdersQuery : IQuery, IPagedQuery
    {
        public int Page { get; init; }
        public int PerPage { get; init; }
        public DateOnly? CreatedDate { get; init; }
        public OrderStatus? Status { get; init; }

        public GetAllOrdersQuery(int page, int perPage, DateOnly? createdDate, OrderStatus? status)
        {
            Page = page;
            PerPage = perPage;
            CreatedDate = createdDate;
            Status = status;
        }
    }
}
