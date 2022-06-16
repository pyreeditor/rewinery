using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.WineGroup.SubcategoriesDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController: ControllerBase
    {
        private readonly SubcategoryRepository _subcategoryRepository;

        public SubcategoriesController(SubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }
        [HttpGet]
        //[Authorize]
        [Route("/api/subcategories/{id}")]
        public async Task<SubcategoryReadDto> GetAsync(int id)
        {
            return await _subcategoryRepository.GetAsync(id);
        }


        [HttpGet]
        public async Task<IEnumerable<SubcategoryReadDto>> GetListAsync()
        {
            return await _subcategoryRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<string> CreateAsync(SubcategoryCreateDto subcategory)
        {
            return await _subcategoryRepository.CreateAsync(subcategory);
        }

        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _subcategoryRepository.DeleteAsync(id);
            return id;
        }

        [HttpPut]
        public async Task<string> UpdateAsync(SubcategoryUpdateDto subcategoryobj)
        {
            await _subcategoryRepository.UpdateAsync(subcategoryobj);
            return subcategoryobj.Name;
        }
    }


}
