using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.WineGroup.Comment;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly CommentRepository _commentRepository;

        public CommentController(CommentRepository commentRepository) => _commentRepository = commentRepository;

        #region get
        [HttpGet]
        [Route("/api/comment/{id}")]
        public async Task<CommentDto> GetAsync(int id)
        {
            return await _commentRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<CommentDto>> GetListAsync()
        {
            return await _commentRepository.GetAllAsync();
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateCommentDto comment)
        {
            return await _commentRepository.CreateAsync(comment);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<CommentDto> UpdateAsync(UpdateCommentDto comment)
        {
            return await _commentRepository.UpdateAsync(comment);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/comment/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _commentRepository.DeleteAsync(id);
        }
        #endregion
    }
}
