using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.Dtos.WineRecipesDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineRecipesController
    {
        private readonly WineRecipeRepository _wineRecipeRepository;

        public WineRecipesController(WineRecipeRepository wineRepository)
        {
            _wineRecipeRepository = wineRepository;
        }

        [Route("/api/winerecipes/{id}")]
        [HttpGet]
        public async Task<WineRecipeReadDto> GetAsync(int id)
        {
            return await _wineRecipeRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<WineRecipeReadDto>> GetListAsync()
        {
            return await _wineRecipeRepository.GetAllAsync();
        }
        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _wineRecipeRepository.DeleteAsync(id);
            return id;
        }
    }
}
