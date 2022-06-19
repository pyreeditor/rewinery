using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.WineGroup.Subcategory;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/subcategories")]
    public class SubcategoriesController: Controller
    {
        private readonly SubcategoryRepository _subcategoryRepository;

        public SubcategoriesController(SubcategoryRepository subcategoryRepository) => _subcategoryRepository = subcategoryRepository;

        #region get
        [HttpGet]
        [Route("/api/subcategories/{id}")]
        public async Task<SubcategoryDto> GetAsync(int id)
        {
            return await _subcategoryRepository.GetAsync(id);
        }


        [HttpGet]
        public async Task<IEnumerable<SubcategoryDto>> GetAllAsync()
        {
            return await _subcategoryRepository.GetAllAsync();
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateSubcategoryDto subcategory)
        {
            return await _subcategoryRepository.CreateAsync(subcategory);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<SubcategoryDto> UpdateAsync(SubcategoryDto subcategory)
        {
            return await _subcategoryRepository.UpdateAsync(subcategory);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/subcategories/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _subcategoryRepository.DeleteAsync(id);
        }
        #endregion
    }
}
