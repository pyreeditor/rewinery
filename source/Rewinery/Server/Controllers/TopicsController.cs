using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Core;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.TopicGroup.TopicsDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController
    {
        private readonly TopicRepository _topicRepository;

        public TopicsController(TopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        [Route("/api/Topic/{id}")]
        [HttpGet]
        public async Task<TopicPageDto> GetAsync(int id)
        {
            return await _topicRepository.GetTopicPageAsync(id);
        }
        [Route("/api/GetShortTopicInfo/{id}")]
        [HttpGet]
        public async Task<IEnumerable<ShortTopicInfoDto>> GetListShortTopicInfoAsync()
        {
            return await _topicRepository.GetAllShortTopicInfoAsync();
        }

        [Route("/api/GetListTopics/{id}")]
        [HttpGet]
        public async Task<IEnumerable<TopicPageDto>> GetListTopicPageDtoAsync()
        {
            return await _topicRepository.GetAllTopicPageAsync();
        }

        [Route("/api/topic/delete/{id}")]
        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _topicRepository.DeleteAsync(id);
            return id;
        }

        [HttpPut]
        public async Task<int> UpdateAsync(TopicUpdateDto wineobj)
        {
            await _topicRepository.UpdateAsync(wineobj);
            return wineobj.Id;
        }

        [HttpPost]
        public async Task<int> CreateAsync(TopicCreateDto answerDto)
        {
            return await _topicRepository.CreateAsync(answerDto);
        }
    }
}
