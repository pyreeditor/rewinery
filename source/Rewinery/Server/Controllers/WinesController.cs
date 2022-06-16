using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.WineGroup.WinesDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinesController
    {
        private readonly WineRepository _wineRepository;

        public WinesController(WineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        [Route("/api/wines/{id}")]
        [HttpGet]
        public async Task<WineRecipePageReadDto> GetAsync(int id)
        {
            return await _wineRepository.GetAsync(id);
        }
        [HttpGet]
        public async Task<IEnumerable<WineRecipePageReadDto>> GetListAsync()
        {
            return await _wineRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<int> CreateAsync(WineCreateDto wine)
        {
            return await _wineRepository.CreateAsync(wine);
        }

        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _wineRepository.DeleteAsync(id);
            return id;
        }

        //[HttpPut]
        //public async Task<int> UpdateAsync(WineUpdateDto wineobj)
        //{
        //    await _wineRepository.UpdateAsync(wineobj);
        //    return wineobj.Id;
        //}
    }
}
