using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.Dtos.IngredientsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    public class IngredientRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public IngredientRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IngredientReadDto> GetAsync(int id)
        {
            var obj = _mapper.Map<IngredientReadDto>(await _ctx.Ingredients.FirstOrDefaultAsync(x=>x.Id==id));
            return obj;
        }

        public async Task<IEnumerable<IngredientReadDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<IngredientReadDto>>(await _ctx.Ingredients.ToListAsync());
        }

        public async Task<string> CreateAsync(IngredientCreateDto ingradientobj)
        {
            var newingredient = _mapper.Map<Ingredient>(ingradientobj);
            newingredient.Name = ingradientobj.Name;
            newingredient.Price = ingradientobj.Price;
            newingredient.Icon = ingradientobj.Icon;
            await _ctx.AddAsync(newingredient);
            await _ctx.SaveChangesAsync();
            return newingredient.Id.ToString();
        }
        public async Task DeleteAsync(int id)
        {
            _ctx.Ingredients.Remove(_ctx.Ingredients.Find(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateASync(IngredientUpdateDto ingredientobj)
        {
            var ingredient = _ctx.Ingredients.FirstOrDefault(x => x.Id == ingredientobj.Id);
            ingredient.Name = ingredientobj.Name;
            ingredient.Icon = ingredientobj.Icon;
            ingredient.Price = ingredientobj.Price;
            await _ctx.SaveChangesAsync();
        }
    }
}
