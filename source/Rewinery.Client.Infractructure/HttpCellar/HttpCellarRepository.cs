using Rewinery.Shared.CellarGroup.Cellar;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure.HttpCellar
{
#pragma warning disable CS8603
    public class HttpCellarRepository : HttpBaseRepository
    {
        public HttpCellarRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<CellarDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<CellarDto>($"api/cellar/{id}");
        }

        public async Task<IEnumerable<CellarDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CellarDto>>($"api/cellar");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateCellarDto cellar)
        {
            await _httpClient.PostAsJsonAsync($"api/cellar", cellar);
        }
        #endregion

        #region update
        public async Task UpdateAsync(UpdateCellarDto cellar)
        {
            await _httpClient.PutAsJsonAsync($"api/cellar", cellar);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"api/cellar/{id}");
        }
        #endregion
    }
}
