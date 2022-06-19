using Rewinery.Shared.WineGroup.Subcategory;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure.HttpWines
{
#pragma warning disable CS8603
    public class HttpSubcategoryRepository : HttpBaseRepository
    {
        public HttpSubcategoryRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<SubcategoryDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<SubcategoryDto>($"api/subcategories/{id}");
        }

        public async Task<IEnumerable<SubcategoryDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<SubcategoryDto>>($"api/subcategories");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateSubcategoryDto subcategory)
        {
            await _httpClient.PostAsJsonAsync($"api/subcategories", subcategory);
        }
        #endregion

        #region update
        public async Task UpdateAsync(SubcategoryDto subcategory)
        {
            await _httpClient.PutAsJsonAsync($"api/subcategories", subcategory);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"api/subcategories/{id}");
        }
        #endregion
    }
}
