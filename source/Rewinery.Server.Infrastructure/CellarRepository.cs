using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Cellars;
using Rewinery.Shared.CellarGroup.Cellar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8602, CS8604
    public class CellarRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public CellarRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<CellarDto> GetAsync(int id)
        {
            return _mapper.Map<CellarDto>(await _ctx.Cellars
                .Include(x => x.CellarRental)
                .FirstAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<CellarDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CellarDto>>(await _ctx.Cellars
                .Include(x => x.CellarRental)
                .ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateCellarDto ccd)
        {
            var cellar = _mapper.Map<Cellar>(ccd);

            await _ctx.Cellars.AddAsync(cellar);
            await _ctx.SaveChangesAsync();

            return cellar.Id;
        }
        #endregion

        #region update
        public async Task<CellarDto> UpdateAsync(UpdateCellarDto ccd)
        {
            var cellar = _ctx.Cellars.Find(ccd.Id);

            cellar.Name = ccd.Name;
            cellar.Capacity = ccd.Capacity;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<CellarDto>(cellar);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.Cellars.Remove(await _ctx.Cellars.FindAsync(id));
            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
