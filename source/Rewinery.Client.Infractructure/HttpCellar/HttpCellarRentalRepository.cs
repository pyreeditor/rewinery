using Rewinery.Shared.CellarGroup.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Client.Infrastructure.HttpCellar
{
#pragma warning disable CS8603
    public class HttpCellarRentalRepository : HttpBaseRepository
    {
        public HttpCellarRentalRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<CellarRentalDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<CellarRentalDto>($"api/cellarrental/{id}");
        }

        public async Task<IEnumerable<CellarRentalDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CellarRentalDto>>($"api/cellarrental");
        }

        public async Task<IEnumerable<CellarRentalDto>> GetByUserNameAsync(string user)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CellarRentalDto>>($"/api/cellarrental/{user}");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateCellarRentalDto rental)
        {
            await _httpClient.PostAsJsonAsync($"api/cellarrental", rental);
        }
        #endregion

        #region update
        public async Task UpdateAsync(UpdateCellarRentalDto rental)
        {
            await _httpClient.PutAsJsonAsync($"api/cellarrental", rental);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"api/cellarrental/{id}");
        }
        #endregion
    }
}
