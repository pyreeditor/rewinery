using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.TopicGroup.AnswerResponsesDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerResponsesController
    {
        private readonly AnswerResponseRepository _answerResponseRepository;

        public AnswerResponsesController(AnswerResponseRepository answerResponseRepository)
        {
            _answerResponseRepository = answerResponseRepository;
        }

        [HttpPost]
        public async Task<int> CreateAsync(AnswerResponseCreateDto answerDto)
        {
            return await _answerResponseRepository.CreateAsync(answerDto);
        }

        [Route("/api/answerResponse/delete/{id}")]
        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _answerResponseRepository.DeleteAsync(id);
            return id;
        }
        [Route("/api/answerResponse/{id}")]
        [HttpGet]
        public async Task<AnswerResponseReadDto> GetAsync(int id)
        {
            return await _answerResponseRepository.GetAsync(id);
        }
    }
}
