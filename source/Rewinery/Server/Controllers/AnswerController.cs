using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.TopicGroup.Answer;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswersController
    {
        private readonly AnswerRepository _answerRepository;

        public AnswersController(AnswerRepository answerRepository) => _answerRepository = answerRepository;
        
        #region get
        [HttpGet]
        [Route("/api/answers/{id}")]
        public async Task<AnswerDto> GetAsync(int id)
        {
            return await _answerRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<AnswerDto>> GetAllAsync()
        {
            return await _answerRepository.GetAllAsync();
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateAnswerDto answer)
        {
            return await _answerRepository.CreateAsync(answer);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<AnswerDto> UpdateAsync(UpdateAnswerDto answer)
        {
            return await _answerRepository.UpdateAsync(answer);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/answers/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _answerRepository.DeleteAsync(id);
        }
        #endregion
    }
}
