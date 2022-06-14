using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.Dtos.CategoriesDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoriesController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        //[Authorize]
        [Route("/api/categories/{id}")]
        public async Task<CategoryReadDto> GetAsync(int id)
        {
            return await _categoryRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryReadDto>> GetListAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<string> CreateAsync(CategoryCreateDto category)
        {
            return await _categoryRepository.CreateAsync(category);
        }

        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return id;
        }

        [HttpPut]
        public async Task<string> UpdateAsync(CategoryUpdateDto categoryobj)
        {
            await _categoryRepository.UpdateAsync(categoryobj);
            return categoryobj.Name;
        }
    }


}
