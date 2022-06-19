using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.WineGroup.Category;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoriesController(CategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

        #region get
        [HttpGet]
        [Route("/api/categories/{id}")]
        public async Task<CategoryDto> GetAsync(int id)
        {
            return await _categoryRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateCategoryDto category)
        {
            return await _categoryRepository.CreateAsync(category);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<CategoryDto> UpdateAsync(CategoryDto category)
        {
            return await _categoryRepository.UpdateAsync(category);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/categories/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }
        #endregion
    }


}
