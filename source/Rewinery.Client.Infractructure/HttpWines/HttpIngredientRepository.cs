using Rewinery.Shared.WineGroup.Ingredient;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure.HttpWines
{
#pragma warning disable CS8603
    public class HttpIngredientRepository : HttpBaseRepository
    {
        public HttpIngredientRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<IngredientDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<IngredientDto>($"/api/ingredients/{id}");
        }

        public async Task<IEnumerable<IngredientDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<IngredientDto>>($"/api/ingredients");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateIngredientDto ingredient)
        {
            await _httpClient.PostAsJsonAsync($"/api/ingredients", ingredient);
        }
        #endregion

        #region update
        public async Task UpdateAsync(UpdateIngredientDto ingredient)
        {
            await _httpClient.PutAsJsonAsync($"/api/ingredients", ingredient);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"/api/ingredients/{id}");
        }
        #endregion
    }
}
