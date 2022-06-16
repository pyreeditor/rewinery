using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.WineGroup.IngredientsDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController
    {
        private readonly IngredientRepository _ingredientRepository;

        public IngredientsController(IngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        [Route("/api/ingredients/{id}")]
        [HttpGet]
        public async Task<IngredientReadDto> GetAsync(int id)
        {
            return await _ingredientRepository.GetAsync(id);
        }
        [HttpGet]
        public async Task<IEnumerable<IngredientReadDto>> GetListAsync()
        {
            return await _ingredientRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<string> CreateAsync(IngredientCreateDto ingredient)
        {
            return await _ingredientRepository.CreateAsync(ingredient);
        }

        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _ingredientRepository.DeleteAsync(id);
            return id;
        }

        [HttpPut]
        public async Task<int> UpdateAsync(IngredientUpdateDto ingredientobj)
        {
            await _ingredientRepository.UpdateASync(ingredientobj);
            return ingredientobj.Id;
        }
    }
}
