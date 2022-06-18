using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.WineGroup.Comment.Response;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentResponsesController
    {
        private readonly CommentResponseRepository _commentResponseRepository;

        public CommentResponsesController(CommentResponseRepository commentResponseRepository) => _commentResponseRepository = commentResponseRepository;
       
        #region get
        [HttpGet]
        [Route("/api/commentresponse/{id}")]
        public async Task<ComResponseDto> GetAsync(int id)
        {
            return await _commentResponseRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ComResponseDto>> GetAllAsync()
        {
            return await _commentResponseRepository.GetAllAsync();
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateComResponseDto commentResponse)
        {
            return await _commentResponseRepository.CreateAsync(commentResponse);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<ComResponseDto> UpdateAsync(UpdateComResponseDto commentResponse)
        {
            return await _commentResponseRepository.UpdateAsync(commentResponse);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/commentresponse/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _commentResponseRepository.DeleteAsync(id);
        }
        #endregion
    }
}
