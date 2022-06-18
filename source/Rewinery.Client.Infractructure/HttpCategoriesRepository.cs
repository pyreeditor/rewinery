using Rewinery.Shared.WineGroup.CategoriesDtos;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure
{
    public class HttpCategoriesRepository : HttpBaseRepository
    {
        public HttpCategoriesRepository(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CategoryReadDto>>($"/api/categories");
        }
    }
}