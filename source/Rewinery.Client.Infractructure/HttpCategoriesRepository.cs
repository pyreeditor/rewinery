using Rewinery.Shared.WineGroup.WinesDtos;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure
{
    public class HttpCategoriesRepository : HttpBaseRepository
    {
        public HttpCategoriesRepository(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<WineRecipePageReadDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<WineRecipePageReadDto>>($"/api/wines");
        }
    }
}