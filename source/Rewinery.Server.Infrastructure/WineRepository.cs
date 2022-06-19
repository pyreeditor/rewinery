using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.Wine;
using Rewinery.Shared.WineGroup.WineRecipePage;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8601, CS8604, CS8620
    public class WineRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;
 
        public WineRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        /// <summary>
        /// Method for obtaining information about one wine by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Wine object with all fields including comments</returns>
        public async Task<WineDto> GetAsync(int id)
        {
            return _mapper.Map<WineDto>(await _ctx.Wines
                .Include(x => x.Owner)
                .Include(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Ingredients)
                .Include(x => x.Comments).ThenInclude(x => x.Responses)
                .FirstAsync(x => x.Id == id));
        }

        /// <summary>
        /// A method for obtaining a list of brief information on each wine
        /// </summary>
        /// <returns>List of objects with abbreviated information about wine</returns>
        public async Task<IEnumerable<ShortWineDto>> GetAllShortAsync()
        {
            return _mapper.Map< IEnumerable<ShortWineDto>>(await _ctx.Wines
                .Include(x => x.Owner)
                .Include(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Ingredients)
                .Where(x => x.Public == true).ToListAsync());
        }

        /// <summary>
        /// A method for obtaining a list of brief information about wines belonging to the user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>List of objects with abbreviated information about wine</returns>
        public async Task<IEnumerable<ShortWineDto>> GetAllByUserNameAsync(string user)
        {
            return _mapper.Map<IEnumerable<ShortWineDto>>(await _ctx.Wines
                .Include(x => x.Owner)
                .Include(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Ingredients)
                .Where(x => x.Owner.UserName == user).ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateWineDto cwd)
        {
            var wine = _mapper.Map<Wine>(cwd);
            wine.Grape = _ctx.Grapes.Find(cwd.GrapeId);
            wine.Owner = _ctx.Users.First(x => x.UserName == cwd.UserName);

            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var ing in cwd.Inredients)
            {
                ingredients.Add(_ctx.Ingredients.Find(ing));
            }

            wine.Ingredients = ingredients;

            await _ctx.Wines.AddAsync(wine);
            await _ctx.SaveChangesAsync();

            return wine.Id;
        }
        #endregion

        #region update
        public async Task<WineDto> UpdateAsync(UpdateWineDto uwd)
        {
            var wine = _ctx.Wines.Find(uwd.Id);
            if (wine != null)
            {
                wine.Name = uwd.Name;
                wine.Description = uwd.Description;
                wine.Icon = uwd.Icon;
                wine.Public = uwd.Public;
            }

            await _ctx.SaveChangesAsync();

            return _mapper.Map<WineDto>(wine);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            var wine = _ctx.Wines.Find(id);

            if (wine != null)
                _ctx.Wines.Remove(wine);
            
            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
