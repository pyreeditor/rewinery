using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.CommentGroup.WineCommentsDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineCommentsController
    {
        private readonly WineCommentRepository _wineCommentRepository;

        public WineCommentsController(WineCommentRepository wineCommentRepository)
        {
            _wineCommentRepository = wineCommentRepository;
        }
        [Route("/api/comment/{id}")]
        [HttpGet]
        public async Task<WineCommentReadDto> GetAsync(int id)
        {
            return await _wineCommentRepository.GetAsync(id);
        }
        [Route("/api/comment/Create/")]
        [HttpPost]
        public async Task<int> CreateAsync(WineCommentCreateDto createDto)
        {
            return await _wineCommentRepository.CreateAsync(createDto);
        }

        [Route("/api/comment/delete/{id}")]
        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _wineCommentRepository.DeleteAsync(id);
            return id;
        }
    }
}
