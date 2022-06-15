using Rewinery.Shared.Dtos.WinesDtos;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure
{
    public class HttpCategoriesRepository : HttpBaseRepository
    {
        public HttpCategoriesRepository(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<WineReadDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<WineReadDto>>($"/api/wines");
        }
    }
}