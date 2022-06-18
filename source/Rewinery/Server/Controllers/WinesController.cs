using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.WineGroup.Wine;
using Rewinery.Shared.WineGroup.WineRecipePage;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WinesController : Controller
    {
        private readonly WineRepository _wineRepository;

        public WinesController(WineRepository wineRepository) => _wineRepository = wineRepository;

        #region get
        [HttpGet]
        [Route("/api/wines/{id}")]
        public async Task<WineDto> GetAsync(int id)
        {
            return await _wineRepository.GetAsync(id);
        }

        [HttpGet]
        [Route("/api/wines/short")]
        public async Task<IEnumerable<ShortWineDto>> GetShortListAsync()
        {
            return await _wineRepository.GetAllShortAsync();
        }

        [HttpGet]
        [Route("/api/wines/short/{user}")]
        public async Task<IEnumerable<ShortWineDto>> GetByUserNameAsync(string user)
        {
            return await _wineRepository.GetAllByUserNameAsync(user);
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateWineDto wine)
        {
            return await _wineRepository.CreateAsync(wine);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<WineDto> UpdateAsync(UpdateWineDto wine)
        {
            return await _wineRepository.UpdateAsync(wine);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/wines/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _wineRepository.DeleteAsync(id);
        }
        #endregion
    }
}
