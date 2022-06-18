using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.Comment.Response;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8601, CS8602, CS8604
    public class CommentResponseRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public CommentResponseRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<ComResponseDto> GetAsync(int id)
        {
            return _mapper.Map<ComResponseDto>(await _ctx.CommentResponses
                .Include(x => x.User).FirstAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<ComResponseDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ComResponseDto>>(await _ctx.CommentResponses
                .Include(x => x.User).ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateComResponseDto ccrd)
        {
            //var commentResponse = _mapper.Map<CommentResponse>(ccrd);
            var commentResponse = new CommentResponse();

            commentResponse.Comment = _ctx.Comments.Find(ccrd.CommentId);
            commentResponse.User = _ctx.Users.First(x => x.UserName == ccrd.User);
            commentResponse.Text = ccrd.Text;
            commentResponse.Created = DateTime.Now;

            await _ctx.CommentResponses.AddAsync(commentResponse);
            await _ctx.SaveChangesAsync();
            return commentResponse.Id;
        }
        #endregion

        #region update
        public async Task<ComResponseDto> UpdateAsync(UpdateComResponseDto ucrd)
        {
            var commentResponse = _ctx.CommentResponses.Find(ucrd.Id);

            commentResponse.Text = ucrd.Text;
            commentResponse.Created = DateTime.Now;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<ComResponseDto>(commentResponse);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.CommentResponses.Remove(_ctx.CommentResponses.Find(id));

            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
