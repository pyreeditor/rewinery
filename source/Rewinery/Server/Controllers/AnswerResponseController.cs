using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.TopicGroup.Answer.Response;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/answerresponses")]
    public class AnswerResponsesController
    {
        private readonly AnswerResponseRepository _answerResponseRepository;

        public AnswerResponsesController(AnswerResponseRepository answerResponseRepository) => _answerResponseRepository = answerResponseRepository;
       
        #region get
        [HttpGet]
        [Route("/api/answerresponses/{id}")]
        public async Task<AnsResponseDto> GetAsync(int id)
        {
            return await _answerResponseRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<AnsResponseDto>> GetAllAsync()
        {
            return await _answerResponseRepository.GetAllAsync();
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateAnsResponseDto response)
        {
            return await _answerResponseRepository.CreateAsync(response);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<AnsResponseDto> UpdateAsync(UpdateAnsResponseDto response)
        {
            return await _answerResponseRepository.UpdateAsync(response);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/answerresponses/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _answerResponseRepository.DeleteAsync(id);
        }
        #endregion
    }
}
