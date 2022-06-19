using Rewinery.Shared.WineGroup.Category;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure.HttpWines
{
#pragma warning disable CS8603
    public class HttpCategoryRepository : HttpBaseRepository
    {
        public HttpCategoryRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<CategoryDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<CategoryDto>($"api/categories/{id}");
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>>($"api/categories");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateCategoryDto category)
        {
            await _httpClient.PostAsJsonAsync($"api/categories", category);
        }
        #endregion

        #region update
        public async Task UpdateAsync(CategoryDto category)
        {
            await _httpClient.PutAsJsonAsync($"api/categories", category);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"api/categories/{id}");
        }
        #endregion
    }
}
