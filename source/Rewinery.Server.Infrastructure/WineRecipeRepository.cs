using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Shared.Dtos.WineRecipesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    public class WineRecipeRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public WineRecipeRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<WineRecipeReadDto> GetAsync(int id)
        {
            return _mapper.Map<WineRecipeReadDto>(await _ctx.WineRecipes
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Wine).ThenInclude(x => x.Ingredients)
                //.Include(x => x.Comments)
                .Include(x=>x.Owner)
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<WineRecipeReadDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<WineRecipeReadDto>>(await _ctx.WineRecipes
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Wine).ThenInclude(x => x.Ingredients)
                //.Include(x => x.Comments)
                .Include(x => x.Owner)
                .ToListAsync());
        }
        public async Task DeleteAsync(int id)
        {
            _ctx.WineRecipes.Remove(_ctx.WineRecipes.Find(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
