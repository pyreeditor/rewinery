using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.WineGroup.Ingredient;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientsController : Controller
    {
        private readonly IngredientRepository _ingredientRepository;

        public IngredientsController(IngredientRepository ingredientRepository) => _ingredientRepository = ingredientRepository;

        #region get
        [HttpGet]
        [Route("/api/ingredients/{id}")]
        public async Task<IngredientDto> GetAsync(int id)
        {
            return await _ingredientRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientDto>> GetAllAsync()
        {
            return await _ingredientRepository.GetAllAsync();
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateIngredientDto ingredient)
        {
            return await _ingredientRepository.CreateAsync(ingredient);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<IngredientDto> UpdateAsync(UpdateIngredientDto ingredient)
        {
            return await _ingredientRepository.UpdateASync(ingredient);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/ingredients/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _ingredientRepository.DeleteAsync(id);
        }
        #endregion
    }
}
