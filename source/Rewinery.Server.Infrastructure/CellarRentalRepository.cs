using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Cellars;
using Rewinery.Shared.CellarGroup.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8601, CS8602, CS8604
    public class CellarRentalRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public CellarRentalRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<CellarRentalDto> GetAsync(int id)
        {
            return _mapper.Map<CellarRentalDto>(await _ctx.CellarRentals
                .Include(x => x.Owner)
                .Include(x => x.Cellar)
                .Include(x => x.Wine).ThenInclude(x => x.Grape)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Wine).ThenInclude(x => x.Ingredients)
                .FirstAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<CellarRentalDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CellarRentalDto>>(await _ctx.CellarRentals
                .Include(x => x.Owner)
                .Include(x => x.Cellar)
                .Include(x => x.Wine).ThenInclude(x => x.Grape)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Wine).ThenInclude(x => x.Ingredients)
                .ToListAsync());
        }

        public async Task<IEnumerable<CellarRentalDto>> GetAllByUserNameAsync(string user)
        {
            return _mapper.Map<IEnumerable<CellarRentalDto>>(await _ctx.CellarRentals
                .Include(x => x.Owner)
                .Include(x => x.Cellar)
                .Include(x => x.Wine).ThenInclude(x => x.Grape)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Wine).ThenInclude(x => x.Ingredients)
                .Where(x => x.Owner.UserName == user)
                .ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateCellarRentalDto ccrd)
        {
            var cellarRental = _mapper.Map<CellarRental>(ccrd);

            cellarRental.Owner = _ctx.Users.First(x => x.UserName == ccrd.UserName);
            cellarRental.Wine = _ctx.Wines.Find(ccrd.WineId);
            cellarRental.Cellar = _ctx.Cellars.Find(ccrd.CellarId);

            cellarRental.StartRental = DateTime.Now;
            cellarRental.EndRental = DateTime.Now.AddMonths(ccrd.RentalTime);

            await _ctx.CellarRentals.AddAsync(cellarRental);
            await _ctx.SaveChangesAsync();

            return cellarRental.Id;
        }
        #endregion

        #region update
        public async Task<CellarRentalDto> UpdateAsync(UpdateCellarRentalDto ucrd)
        {
            var cellarRental = _ctx.CellarRentals.Find(ucrd.Id);

            cellarRental.Number = ucrd.Number;
            cellarRental.EndRental.AddMonths(ucrd.RentalTime);

            await _ctx.SaveChangesAsync();

            return _mapper.Map<CellarRentalDto>(cellarRental);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.CellarRentals.Remove(await _ctx.CellarRentals.FindAsync(id));
            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
