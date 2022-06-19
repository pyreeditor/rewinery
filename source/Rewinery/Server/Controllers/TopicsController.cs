using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.TopicGroup.Topic;
using Rewinery.Shared.TopicGroup.TopicPage;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/topics")]
    public class TopicsController : Controller
    {
        private readonly TopicRepository _topicRepository;

        public TopicsController(TopicRepository topicRepository) => _topicRepository = topicRepository;

        #region get
        [HttpGet]
        [Route("/api/topics/{id}")]
        public async Task<TopicDto> GetAsync(int id)
        {
            return await _topicRepository.GetAsync(id);
        }

        [HttpGet]
        [Route("/api/topic/short")]
        public async Task<IEnumerable<ShortTopicDto>> GetAllShortAsync()
        {
            return await _topicRepository.GetAllShortAsync();
        }

        [HttpGet]
        [Route("/api/topic/short/{user}")]
        public async Task<IEnumerable<ShortTopicDto>> GetAllByUserNameAsync(string user)
        {
            return await _topicRepository.GetAllByUserNameAsync(user);
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateTopicDto topic)
        {
            return await _topicRepository.CreateAsync(topic);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<TopicDto> UpdateAsync(UpdateTopicDto topic)
        {
            return await _topicRepository.UpdateAsync(topic);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/topics/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _topicRepository.DeleteAsync(id);
        }
        #endregion
    }
}
