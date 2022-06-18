using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Comment;
using Rewinery.Shared.CommentGroup.WineCommentsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    public class WineCommentRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public WineCommentRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<WineCommentReadDto> GetAsync(int id)
        {
            return _mapper.Map<WineCommentReadDto>(await _ctx.WineComments
                .Include(x => x.Responses).ThenInclude(x => x.User)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<WineCommentReadDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<WineCommentReadDto>>(await _ctx.WineComments
                .Include(x => x.Responses).ThenInclude(x => x.User)
                .Include(x => x.User)
                .ToListAsync()
                );
        }

        public async Task DeleteAsync(int id)
        {
            _ctx.WineComments.Remove(_ctx.WineComments.Find(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(WineCommentCreateDto createDto)
        {
            var nComment = _mapper.Map<WineComment>(createDto);
            nComment.Comment = createDto.CommentText;
            nComment.Created = DateTime.Now;
            nComment.Wine = _ctx.Wines.Find(createDto.WineId);
            nComment.User = await _ctx.Users.FirstOrDefaultAsync(x=>x.UserName == createDto.OwnerUserName);
            await _ctx.WineComments.AddAsync(nComment);
            await _ctx.SaveChangesAsync();
            return nComment.Id;
        }
    }
}
