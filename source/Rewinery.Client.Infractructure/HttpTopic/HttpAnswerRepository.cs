using Rewinery.Shared.TopicGroup.Answer;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure.HttpTopic
{
#pragma warning disable CS8603
    public class HttpAnswerRepository : HttpBaseRepository
    {
        public HttpAnswerRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<AnswerDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<AnswerDto>($"api/answers/{id}");
        }

        public async Task<IEnumerable<AnswerDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<AnswerDto>>($"api/answers");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateAnswerDto answer)
        {
            await _httpClient.PostAsJsonAsync($"api/answers", answer);
        }
        #endregion

        #region update
        public async Task UpdateAsync(UpdateAnswerDto answer)
        {
            await _httpClient.PutAsJsonAsync($"api/answers", answer);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"api/answers/{id}");
        }
        #endregion
    }
}
