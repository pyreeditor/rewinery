using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.TopicGroup.AnswersDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController
    {
        private readonly AnswerRepository _answerRepository;

        public AnswersController(AnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }
        [Route("/api/answer/{id}")]
        [HttpGet]
        public async Task<AnswerReadDto> GetAsync(int id)
        {
            return await _answerRepository.GetAsync(id);
        }

        [HttpPost]
        public async Task<int> CreateAsync(AnswerCreateDto answerDto)
        {
            return await _answerRepository.CreateAsync(answerDto);
        }

        [Route("/api/answer/delete/{id}")]
        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _answerRepository.DeleteAsync(id);
            return id;
        }
    }
}
