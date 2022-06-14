using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.Dtos.GrapesDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrapesController : ControllerBase
    {
        private readonly GrapeRepository _grapeRepository;

        public GrapesController(GrapeRepository grapeRepository)
        {
            _grapeRepository = grapeRepository;
        }

        [Route("/api/grapes/{id}")]
        [HttpGet]
        public async Task<GrapeReadDto> GetAsync(int id)
        {
            return await _grapeRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<GrapeReadDto>> GetListAsync()
        {
            return await _grapeRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<string> CreateAsync(GrapeCreateDto grape)
        {
            return await _grapeRepository.CreateAsync(grape);
        }

        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _grapeRepository.DeleteAsync(id);
            return id;
        }

        [HttpPut]
        public async Task<int> UpdateAsync(GrapeUpdateDto grapeobj)
        {
            await _grapeRepository.UpdateAsync(grapeobj);
            return grapeobj.Id;
        }
    }
}
