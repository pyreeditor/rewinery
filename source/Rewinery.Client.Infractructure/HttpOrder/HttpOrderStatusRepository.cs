using Rewinery.Shared.OrderGroup.OrderStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Client.Infrastructure.HttpOrder
{
#pragma warning disable CS8603
    public class HttpOrderStatusRepository : HttpBaseRepository
    {
        public HttpOrderStatusRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<OrderStatusDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<OrderStatusDto>($"api/orderstatus/{id}");
        }

        public async Task<IEnumerable<OrderStatusDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OrderStatusDto>>($"api/orderstatus");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateOrderStatusDto status)
        {
            await _httpClient.PostAsJsonAsync($"api/orderstatus", status);
        }
        #endregion

        #region update
        public async Task UpdateAsync(OrderStatusDto status)
        {
            await _httpClient.PutAsJsonAsync($"api/orderstatus", status);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"api/orderstatus/{id}");
        }
        #endregion
    }
}
