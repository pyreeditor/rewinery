using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.WineGroup.Comment.Response;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/commentresponses")]
    public class CommentResponsesController
    {
        private readonly CommentResponseRepository _commentResponseRepository;

        public CommentResponsesController(CommentResponseRepository commentResponseRepository) => _commentResponseRepository = commentResponseRepository;
       
        #region get
        [HttpGet]
        [Route("/api/commentresponses/{id}")]
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
        public async Task<int> CreateAsync(CreateComResponseDto response)
        {
            return await _commentResponseRepository.CreateAsync(response);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<ComResponseDto> UpdateAsync(UpdateComResponseDto response)
        {
            return await _commentResponseRepository.UpdateAsync(response);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/commentresponses/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _commentResponseRepository.DeleteAsync(id);
        }
        #endregion
    }
}
