using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.WinesDtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Rewinery.Server.Infrastructure
{
    public class WineRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;
        //private readonly HttpContextAccessor _httpContextAccessor;

        public WineRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<WineRecipePageReadDto> GetAsync(int id)
        {
            return _mapper.Map<WineRecipePageReadDto>(await _ctx.Wines
                .Include(x => x.Ingredients)
                .Include(x=>x.Grape)
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<WineRecipePageReadDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<WineRecipePageReadDto>>(await _ctx.Wines
                .Include(x => x.Ingredients).Include(x=>x.Grape)
                .ToListAsync());
        }
        public async Task DeleteAsync(int id)
        {
            _ctx.Wines.Remove(_ctx.Wines.Find(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(WineCreateDto wineobj)
        {
            var newwine = _mapper.Map<Wine>(wineobj);
            newwine.Name = wineobj.Name;
            newwine.Description = wineobj.Description;
            newwine.Grape = _ctx.Grapes.Find(wineobj.GrapeId);

            List<Ingredient> temping = new List<Ingredient>();

            foreach (var item in wineobj.IngredientsIds)
            {
                var ing = _ctx.Ingredients.Find(item);
                temping.Add(ing);
                newwine.Price += ing.Price;
            }
            newwine.Ingredients = temping;
            await _ctx.Wines.AddAsync(newwine);
            await _ctx.SaveChangesAsync();
            return newwine.Id;
        }
        //public async Task<int> UpdateAsync(WineUpdateDto wineobj)
        //{
        //    var wine = _ctx.Wines.Find(wineobj.Id);
        //    wine.Name = wineobj.Name;
        //    wine.Description = wineobj.Description;
        //    wine.Grape = _ctx.Grapes.Find(wineobj.GrapeId);
        //    wine.Price = _ctx.Grapes.Find(wineobj.GrapeId).Price;

        //    List<Ingredient> temping = new List<Ingredient>();
        //    foreach (var item in wineobj.IngredientsIds)
        //    {
        //        var ing = _ctx.Ingredients.Find(item);
        //        temping.Add(ing);
        //        wine.Price += ing.Price;
        //    }

        //    wine.Ingredients = temping;
        //    await _ctx.SaveChangesAsync();
        //    return wine.Id;
        //}
    }
}
