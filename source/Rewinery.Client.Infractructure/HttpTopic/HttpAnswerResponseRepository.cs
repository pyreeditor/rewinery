using Rewinery.Shared.TopicGroup.Answer.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Client.Infrastructure.HttpTopic
{
#pragma warning disable CS8603
    public class HttpAnswerResponseRepository : HttpBaseRepository
    {
        public HttpAnswerResponseRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        public async Task<AnsResponseDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<AnsResponseDto>($"api/answerresponses/{id}");
        }

        public async Task<IEnumerable<AnsResponseDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<AnsResponseDto>>($"api/answerresponses");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateAnsResponseDto response)
        {
            await _httpClient.PostAsJsonAsync($"api/answerresponses", response);
        }
        #endregion

        #region update
        public async Task UpdateAsync(UpdateAnsResponseDto response)
        {
            await _httpClient.PutAsJsonAsync($"api/answerresponses", response);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"api/answerresponses/{id}");
        }
        #endregion
    }
}
