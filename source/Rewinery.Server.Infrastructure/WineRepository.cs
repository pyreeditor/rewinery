using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.Dtos.WinesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    public class WineRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public WineRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<WineReadDto> GetAsync(int id)
        {
            var obj = _mapper.Map<WineReadDto>(await _ctx.Wines.Include(x => x.Grape).ThenInclude(x => x.Category).FirstOrDefaultAsync(x => x.Id == id));
            return obj;
        }

        public async Task<IEnumerable<WineReadDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<WineReadDto>>(await _ctx.Wines.Include(x => x.Grape).ThenInclude(x => x.Category).ToListAsync());
        }
        public async Task DeleteAsync(int id)
        {
            _ctx.Wines.Remove(_ctx.Wines.Find(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task<Wine> CreateAsync(WineCreateDto wineobj)
        {
            var newwine = _mapper.Map<Wine>(wineobj);
            newwine.Name = wineobj.Name;
            newwine.Description = wineobj.Description;
            newwine.Grape = _ctx.Grapes.Find(wineobj.GrapeId);
            newwine.Price = _ctx.Grapes.Find(wineobj.GrapeId).Price;
            List<Ingredient> temping=new List<Ingredient>();

            foreach (var item in wineobj.IngredientsIds)
            {
                var ing = _ctx.Ingredients.Find(item);
                temping.Add(ing);
                newwine.Price += ing.Price;
            }
            newwine.Ingredients = temping;

            await _ctx.SaveChangesAsync();
            return newwine;
        }
    }
}
