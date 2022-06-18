using Rewinery.Shared.WineGroup.IngredientsDtos;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure
{
    public class HttpIngredientRepository : HttpBaseRepository
    {
        public HttpIngredientRepository(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<IngredientReadDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<IngredientReadDto>>($"/api/ingredients");
        }
    }
}
