using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.Category;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8602, CS8604
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<CategoryDto> GetAsync(int id)
        {
            return _mapper.Map<CategoryDto>(await _ctx.Categories.FindAsync(id));
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _ctx.Categories.ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateCategoryDto ccd)
        {
            var category = _mapper.Map<Category>(ccd);

            await _ctx.Categories.AddAsync(category);
            await _ctx.SaveChangesAsync();

            return category.Id;
        }
        #endregion

        #region update
        public async Task<CategoryDto> UpdateAsync(CategoryDto cd)
        {
            var category = _ctx.Categories.Find(cd.Id);

            category.Name = cd.Name;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.Categories.Remove(await _ctx.Categories.FindAsync(id));
            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
