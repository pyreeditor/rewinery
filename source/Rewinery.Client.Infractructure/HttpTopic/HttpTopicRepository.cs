using Rewinery.Shared.TopicGroup.Topic;
using Rewinery.Shared.TopicGroup.TopicPage;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure.HttpTopic
{
#pragma warning disable CS8603
    public class HttpTopicRepository : HttpBaseRepository
    {
        public HttpTopicRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<TopicDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<TopicDto>($"api/topics/{id}");
        }

        public async Task<IEnumerable<ShortTopicDto>> GetAllShortAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ShortTopicDto>>($"api/topics/short");
        }

        public async Task<IEnumerable<ShortTopicDto>> GetAllByUserNameAsync(string user)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ShortTopicDto>>($"/api/topics/short/{user}");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateTopicDto topic)
        {
            await _httpClient.PostAsJsonAsync($"api/topics", topic);
        }
        #endregion

        #region update
        public async Task UpdateAsync(UpdateTopicDto topic)
        {
            await _httpClient.PutAsJsonAsync($"api/topics", topic);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"api/topics/{id}");
        }
        #endregion
    }
}
