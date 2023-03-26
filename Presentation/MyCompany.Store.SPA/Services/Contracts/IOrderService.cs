using MyCompany.Store.SPA.Enums;
using MyCompany.Store.SPA.Models;

namespace MyCompany.Store.SPA.Services.Contracts
{
    public interface IOrderService
	{
		Task<QueryResult<IEnumerable<OrderListModel>>> GetAllOrdersAsync(int page, int perPage = 10, OrderStatus? status = null, DateTime? createdDate = null);
		Task<OrderDetailsModel> GetAsync(long orderId);
		Task RemoveAsync(long orderId);
		Task AddAsync(OrderFormsModel order);
	}
}
 