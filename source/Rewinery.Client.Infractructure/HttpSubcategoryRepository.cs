using Rewinery.Shared.WineGroup.SubcategoriesDtos;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure
{
    public class HttpSubcategoryRepository : HttpBaseRepository
    {
        public HttpSubcategoryRepository(HttpClient httpClient) : base(httpClient) { }
       
        public async Task<IEnumerable<SubcategoryReadDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<SubcategoryReadDto>>($"/api/subcategories");
        }
    }
}
