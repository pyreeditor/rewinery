using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.Dtos.CategoriesDtos;

namespace Rewinery.Server.Infrastructure
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<CategoryReadDto> GetAsync(int id)
        {
            var obj = _mapper.Map<CategoryReadDto>(await _ctx.Categories.FirstOrDefaultAsync(x => x.Id == id));
            return obj;
        }

        public async Task<string> CreateAsync(CategoryCreateDto categoryobj, string categoryName)
        {
            var newcategory = _mapper.Map<Category>(categoryobj);
            newcategory.Name = categoryName;
            await _ctx.Categories.AddAsync(newcategory);
            await _ctx.SaveChangesAsync();
            return newcategory.Id.ToString();
        }
        public async Task DeleteAsync(int id)
        {
            _ctx.Categories.Remove(await _ctx.Categories.FindAsync(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryUpdateDto categoryobj)
        {
            var category = _ctx.Categories.Find(categoryobj.Id);
            category.Name = categoryobj.Name;
            await _ctx.SaveChangesAsync();
        }
    }
}
