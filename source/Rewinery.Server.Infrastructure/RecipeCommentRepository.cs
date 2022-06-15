using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Shared.Dtos.RecipeCommentsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    public class RecipeCommentRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public RecipeCommentRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<RecipeCommentReadDto> GetAsync(int id)
        {
            return _mapper.Map<RecipeCommentReadDto>(_ctx.RecipeComments.Include(x=>x.User).Include(x=>x.Recipe).Include(x=>x.Responses));
        }
    }
}
