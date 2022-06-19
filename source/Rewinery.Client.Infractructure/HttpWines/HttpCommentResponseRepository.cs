using Rewinery.Shared.WineGroup.Comment.Response;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure.HttpWines
{
#pragma warning disable CS8603
    public class HttpCommentResponseRepository : HttpBaseRepository
    {
        public HttpCommentResponseRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<ComResponseDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<ComResponseDto>($"/api/commentresponses/{id}");
        }

        public async Task<IEnumerable<ComResponseDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ComResponseDto>>($"/api/commentresponses");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateComResponseDto response)
        {
            await _httpClient.PostAsJsonAsync($"/api/commentresponses", response);
        }
        #endregion

        #region update
        public async Task UpdateAsync(UpdateComResponseDto response)
        {
            await _httpClient.PutAsJsonAsync($"/api/commentresponses", response);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"/api/commentresponses/{id}");
        }
        #endregion
    }
}
