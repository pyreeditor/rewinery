using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.Subcategory;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8602, CS8604
    public class SubcategoryRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public SubcategoryRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<SubcategoryDto> GetAsync(int id)
        {
            return _mapper.Map<SubcategoryDto>(await _ctx.Subcategories.FirstAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<SubcategoryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<SubcategoryDto>>(await _ctx.Subcategories.ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateSubcategoryDto csd)
        {
            var subcategory = _mapper.Map<Subcategory>(csd);

            await _ctx.Subcategories.AddAsync(subcategory);
            await _ctx.SaveChangesAsync();

            return subcategory.Id;
        }
        #endregion

        #region update
        public async Task<SubcategoryDto> UpdateAsync(SubcategoryDto sd)
        {
            var subcategory = _ctx.Subcategories.Find(sd.Id);

            subcategory.Name = sd.Name;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<SubcategoryDto>(subcategory);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.Subcategories.Remove(await _ctx.Subcategories.FindAsync(id));

            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
