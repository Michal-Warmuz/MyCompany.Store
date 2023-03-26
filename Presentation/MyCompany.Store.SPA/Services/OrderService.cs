using MyCompany.Store.SPA.Enums;
using MyCompany.Store.SPA.Models;
using MyCompany.Store.SPA.Services.Contracts;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MyCompany.Store.SPA.Services
{
    public class OrderService : IOrderService
	{
		private readonly HttpClient _httpClient;

		public OrderService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

        public async Task<OrderDetailsModel> GetAsync(long orderId)
        {
            var response = await _httpClient.GetAsync($"/api/Orders/{orderId}");

            var result = await
                response.Content.ReadFromJsonAsync<QueryResult<OrderDetailsModel>>();


            if (!string.IsNullOrEmpty(result.Error))
                throw new Exception(result.Error);


            return result.Payload;
        }

        public async Task<QueryResult<IEnumerable<OrderListModel>>> GetAllOrdersAsync(int page, int perPage = 10, OrderStatus? status = null, DateTime? createdDate = null)
		{

            StringBuilder url = new StringBuilder($"/api/Orders?page={page}&perPage={perPage}");

            if(createdDate.HasValue)
            {
                url.Append($"&createdDate={createdDate.Value.ToString("yyyy-MM-dd")}");
            }

            if(status.HasValue)
            {
                var statusName = status.ToString();
                url.Append($"&status={statusName}");
            }

            var response = await _httpClient.GetAsync(url.ToString());

            var result = await
                response.Content.ReadFromJsonAsync<QueryResult<IEnumerable<OrderListModel>>>();


            if (!string.IsNullOrEmpty(result.Error))
                throw new Exception(result.Error);


            return result;

        }

        public async Task RemoveAsync(long orderId)
        {
            var response = await _httpClient.DeleteAsync($"/api/Orders/{orderId}");

            var result = await response.Content.ReadFromJsonAsync<CommandResult>();

            if (!string.IsNullOrEmpty(result.Error))
                throw new Exception(result.Error);
        }

        public async Task AddAsync(OrderAddFormModel order)
        {

            var jsonOrder = JsonSerializer.Serialize(order);

            var content = new StringContent(jsonOrder, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/Orders/", content);

            if(!response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<CommandResult>();

                if (!string.IsNullOrEmpty(result.Error))
                    throw new Exception(result.Error);
            }
        }

        public async Task UpdateAsync(long orderId, OrderEditFormModel order)
        {
            var jsonOrder = JsonSerializer.Serialize(order);

            var content = new StringContent(jsonOrder, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/api/Orders/{orderId}", content);

            if (!response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<CommandResult>();

                if (!string.IsNullOrEmpty(result.Error))
                    throw new Exception(result.Error);
            }
        }
    }
}
