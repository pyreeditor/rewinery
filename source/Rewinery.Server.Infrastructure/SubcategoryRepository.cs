using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.SubcategoriesDtos;

namespace Rewinery.Server.Infrastructure
{
    public class SubcategoryRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public SubcategoryRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<SubcategoryReadDto> GetAsync(int id)
        {
            var obj = _mapper.Map<SubcategoryReadDto>(await _ctx.Subcategories.FirstOrDefaultAsync(x => x.Id == id));
            return obj;
        }

        public async Task<IEnumerable<SubcategoryReadDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<SubcategoryReadDto>>(await _ctx.Subcategories.ToListAsync());
        }

        public async Task<string> CreateAsync(SubcategoryCreateDto subcategoryobj)
        {
            var newSubcategory = _mapper.Map<Subcategory>(subcategoryobj);
            newSubcategory.Name = subcategoryobj.Name;
            await _ctx.Subcategories.AddAsync(newSubcategory);
            await _ctx.SaveChangesAsync();
            return newSubcategory.Id.ToString();
        }
        public async Task DeleteAsync(int id)
        {
            _ctx.Subcategories.Remove(await _ctx.Subcategories.FindAsync(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubcategoryUpdateDto subcategoryobj)
        {
            var subcategory = _ctx.Subcategories.Find(subcategoryobj.Id);
            subcategory.Name = subcategoryobj.Name;
            await _ctx.SaveChangesAsync();
        }
    }
}
