using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.CommentGroup.CommentResponsesDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentResponsesController
    {
        private readonly CommentResponseRepository _commentResponseRepository;

        public CommentResponsesController(CommentResponseRepository commentResponseRepository)
        {
            _commentResponseRepository = commentResponseRepository;
        }

        [Route("/api/commentResponse/{id}")]
        [HttpGet]
        public async Task<CommentResponseReadDto> GetAsync(int id)
        {
            return await _commentResponseRepository.GetAsync(id);
        }
        [Route("/api/commentResponse/Create")]
        [HttpPost]
        public async Task<int> CreateAsync(CommentResponseCreateDto createDto)
        {
            return await _commentResponseRepository.CreateAsync(createDto);
        }

        [Route("/api/commnetResponse/delete/{id}")]
        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _commentResponseRepository.DeleteAsync(id);
            return id;
        }
    }
}
