using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.WinesDtos;

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

        public async Task<WineRecipePageReadDto> GetAsync(int id)
        {
            return _mapper.Map<WineRecipePageReadDto>(await _ctx.Wines
                .Include(x => x.Ingredients)
                .Include(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Comments).ThenInclude(x => x.User)
                .Include(x=>x.Comments).ThenInclude(x=>x.Responses)
                .Include(x => x.Owner)
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<WineRecipePageReadDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<WineRecipePageReadDto>>(await _ctx.Wines
                .Include(x => x.Ingredients)
                .Include(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Comments).ThenInclude(x => x.User)
                .Include(x => x.Comments).ThenInclude(x => x.Responses)
                .Include(x => x.Owner)
                .ToListAsync());
        }
        public async Task<IEnumerable<WineRecipePageReadDto>> GetAllByUserNameAsync(string userName)
        {
            return _mapper.Map<IEnumerable<WineRecipePageReadDto>>(await _ctx.Wines
                .Include(x => x.Ingredients)
                .Include(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Comments).ThenInclude(x => x.User)
                .Include(x => x.Comments).ThenInclude(x => x.Responses)
                .Include(x => x.Owner).Where(x=>x.Owner.UserName== userName)
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
            newwine.Owner = _ctx.Users.FirstOrDefault(x => x.UserName == wineobj.OwnerUserName);
            await _ctx.Wines.AddAsync(newwine);
            await _ctx.SaveChangesAsync();
            return newwine.Id;
        }
        public async Task<int> UpdateAsync(WineUpdateDto wineobj)
        {
            var wine = _ctx.Wines.Find(wineobj.Id);
            wine.Name = wineobj.Name;
            wine.Description = wineobj.Description;
            wine.Icon = wineobj.Icon;
            wine.Public = wineobj.Public;
            await _ctx.SaveChangesAsync();
            return wine.Id;
        }
    }
}
