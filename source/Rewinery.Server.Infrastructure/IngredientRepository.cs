using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.Ingredient;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8601, CS8602, CS8604, CS8620
    public class IngredientRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public IngredientRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<IngredientDto> GetAsync(int id)
        {
            return _mapper.Map<IngredientDto>(await _ctx.Ingredients.FirstAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<IngredientDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<IngredientDto>>(await _ctx.Ingredients.ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateIngredientDto cid)
        {
            var ingredient = _mapper.Map<Ingredient>(cid);

            await _ctx.AddAsync(ingredient);
            await _ctx.SaveChangesAsync();

            return ingredient.Id;
        }
        #endregion

        #region update
        public async Task<IngredientDto> UpdateASync(UpdateIngredientDto uid)
        {
            var ingredient = _ctx.Ingredients.FirstOrDefault(x => x.Id == uid.Id);

            ingredient.Name = uid.Name;
            ingredient.Icon = uid.Icon;
            ingredient.Price = uid.Price;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<IngredientDto>(ingredient);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.Ingredients.Remove(_ctx.Ingredients.Find(id));

            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
