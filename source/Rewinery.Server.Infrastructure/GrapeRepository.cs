using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.Grape;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8601, CS8602
    public class GrapeRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public GrapeRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<GrapeDto> GetAsync(int Id)
        {
            return _mapper.Map<GrapeDto>(await _ctx.Grapes
                .Include(x => x.Category)
                .Include(x => x.Subcategory)
                .FirstAsync(x => x.Id == Id));
        }

        public async Task<IEnumerable<GrapeDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GrapeDto>>(await _ctx.Grapes
                .Include(x => x.Category)
                .Include(x => x.Subcategory)
                .ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateGrapeDto cgd)
        {
            var grape = _mapper.Map<Grape>(cgd);

            grape.Category = _ctx.Categories.Find(cgd.CategoryId);
            grape.Subcategory = _ctx.Subcategories.Find(cgd.SubcategoryId);

            await _ctx.Grapes.AddAsync(grape);
            await _ctx.SaveChangesAsync();

            return grape.Id;
        }
        #endregion

        #region update
        public async Task<GrapeDto> UpdateAsync(UpdateGrapeDto ugd)
        {
            var grape = _ctx.Grapes.Find(ugd.Id);

            grape.Name = ugd.Name;
            grape.Icon = ugd.Icon;
            grape.Price = ugd.Price;
            grape.Category = _ctx.Categories.Find(ugd.CategoryId);
            grape.Subcategory = _ctx.Subcategories.Find(ugd.SubcategoryId);

            await _ctx.SaveChangesAsync();

            return _mapper.Map<GrapeDto>(grape);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            var grape = _ctx.Grapes.Find(id);

            if (grape != null)
                _ctx.Grapes.Remove(grape);

            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
