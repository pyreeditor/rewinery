using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Comment;
using Rewinery.Shared.CommentGroup.CommentResponsesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    public class CommentResponseRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public CommentResponseRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<CommentResponseReadDto> GetAsync(int id)
        {
            return _mapper.Map<CommentResponseReadDto>(await _ctx.CommentResponses
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task DeleteAsync(int id)
        {
            _ctx.CommentResponses.Remove(_ctx.CommentResponses.Find(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(CommentResponseCreateDto createDto)
        {
            var nComRes = _mapper.Map<CommentResponse>(createDto);
            nComRes.Comment = _ctx.WineComments.Find(createDto.CommentId);
            nComRes.Created = DateTime.Now;
            nComRes.Response = createDto.Response;
            nComRes.User = await _ctx.Users.FirstOrDefaultAsync(x=>x.UserName==createDto.OwnerUserName);
            await _ctx.CommentResponses.AddAsync(nComRes);
            await _ctx.SaveChangesAsync();
            return nComRes.Id;
        }
    }
}
