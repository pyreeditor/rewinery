using Rewinery.Shared.OrderGroup.Orders;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure.HttpOrder
{
#pragma warning disable CS8603
    public class HttpOrderRepository : HttpBaseRepository
    {
        public HttpOrderRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<OrderDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<OrderDto>($"api/order/{id}");
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OrderDto>>($"api/order");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateOrderDto order)
        {
            await _httpClient.PostAsJsonAsync($"api/order", order);
        }
        #endregion

        #region update
        public async Task UpdateAsync(UpdateOrderDto order)
        {
            await _httpClient.PutAsJsonAsync($"api/order", order);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"api/order/{id}");
        }
        #endregion
    }
}
