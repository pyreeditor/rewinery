using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8602, CS8601, CS8604, CS8620
    public class CommentRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public CommentRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<CommentDto> GetAsync(int id)
        {
            return _mapper.Map<CommentDto>(await _ctx.Comments
                .Include(x => x.User)
                .Include(x => x.Responses)
                .FirstAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<CommentDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CommentDto>>(await _ctx.Comments
                .Include(x => x.User)
                .Include(x => x.Responses)
                .ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateCommentDto ccd)
        {
            //var comment = _mapper.Map<Comment>(ccd);
            var comment = new Comment();

            comment.User = _ctx.Users.First(x => x.UserName == ccd.User);
            comment.Wine = _ctx.Wines.Find(ccd.WineId);
            comment.Created = DateTime.Now;
            comment.Text = ccd.Text;

            await _ctx.Comments.AddAsync(comment);
            await _ctx.SaveChangesAsync();

            return comment.Id;
        }
        #endregion

        #region update
        public async Task<CommentDto> UpdateAsync(UpdateCommentDto ucd)
        {
            var comment = _ctx.Comments.Find(ucd.Id);

            comment.Text = ucd.Text;
            comment.Created = DateTime.Now;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<CommentDto>(comment);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.Comments.Remove(await _ctx.Comments.FindAsync(id));
            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
