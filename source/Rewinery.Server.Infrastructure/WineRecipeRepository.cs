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
            return _mapper.Map<WineRecipeReadDto>(await _ctx.WineRecipes.FirstOrDefaultAsync(x=>x.Id==id));
        }
    }
}
