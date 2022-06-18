using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.WineGroup.Grape;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrapesController : Controller
    {
        private readonly GrapeRepository _grapeRepository;

        public GrapesController(GrapeRepository grapeRepository) => _grapeRepository = grapeRepository;

        #region get
        [HttpGet]
        [Route("/api/grapes/{id}")]
        public async Task<GrapeDto> GetAsync(int id)
        {
            return await _grapeRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<GrapeDto>> GetListAsync()
        {
            return await _grapeRepository.GetAllAsync();
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateGrapeDto grape)
        {
            return await _grapeRepository.CreateAsync(grape);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<GrapeDto> UpdateAsync(UpdateGrapeDto grape)
        {
            return await _grapeRepository.UpdateAsync(grape);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/grapes/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _grapeRepository.DeleteAsync(id);
        }
        #endregion
    }
}
