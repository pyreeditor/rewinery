using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.CellarGroup.Cellar;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/cellar")]
    public class CellarController : Controller
    {
        private readonly CellarRepository _cellarRepository;

        public CellarController(CellarRepository cellarRepository) => _cellarRepository = cellarRepository;

        #region get
        [HttpGet]
        [Route("/api/cellar/{id}")]
        public async Task<CellarDto> GetAsync(int id)
        {
            return await _cellarRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<CellarDto>> GetListAsync()
        {
            return await _cellarRepository.GetAllAsync();
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateCellarDto cellar)
        {
            return await _cellarRepository.CreateAsync(cellar);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<CellarDto> UpdateAsync(UpdateCellarDto cellar)
        {
            return await _cellarRepository.UpdateAsync(cellar);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/cellar/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _cellarRepository.DeleteAsync(id);
        }
        #endregion
    }
}
