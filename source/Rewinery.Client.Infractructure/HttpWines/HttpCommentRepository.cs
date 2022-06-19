using Rewinery.Shared.WineGroup.Comment;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure.HttpWines
{
#pragma warning disable CS8603
    public class HttpCommentRepository : HttpBaseRepository
    {
        public HttpCommentRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<CommentDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<CommentDto>($"/api/comment/{id}");
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CommentDto>>($"/api/comment");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateCommentDto comment)
        {
            await _httpClient.PostAsJsonAsync($"/api/comment", comment);
        }
        #endregion

        #region update
        public async Task UpdateAsync(UpdateCommentDto comment)
        {
            await _httpClient.PutAsJsonAsync($"/api/comment", comment);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"/api/comment/{id}");
        }
        #endregion
    }
}
