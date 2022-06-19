using Rewinery.Shared.WineGroup.Grape;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure.HttpWines
{
#pragma warning disable CS8603
    public class HttpGrapeRepository : HttpBaseRepository
    {
        public HttpGrapeRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<GrapeDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GrapeDto>($"/api/grapes/{id}");
        }

        public async Task<IEnumerable<GrapeDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<GrapeDto>>($"/api/grapes");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateGrapeDto grape)
        {
            await _httpClient.PostAsJsonAsync($"/api/grapes", grape);
        }
        #endregion

        #region update
        public async Task UpdateAsync(UpdateGrapeDto grape)
        {
            await _httpClient.PutAsJsonAsync($"/api/grapes", grape);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"/api/grapes/{id}");
        }
        #endregion
    }
}
