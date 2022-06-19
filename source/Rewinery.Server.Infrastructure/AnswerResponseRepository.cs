using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Topics;
using Rewinery.Shared.TopicGroup.Answer.Response;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8602, CS8601, CS8604, CS8620
    public class AnswerResponseRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public AnswerResponseRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<AnsResponseDto> GetAsync(int id)
        {
            return _mapper.Map<AnsResponseDto>(await _ctx.AnswerResponses
                .Include(x=>x.User).FirstAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<AnsResponseDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AnsResponseDto>>(await _ctx.AnswerResponses
                .Include(x => x.User).ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateAnsResponseDto card)
        {
            var response = _mapper.Map<AnswerResponse>(card);

            response.User = _ctx.Users.First(x => x.UserName == card.UserName);
            response.Answer = _ctx.Answers.Find(card.AnswerId);
            response.Created = DateTime.Now;

            await _ctx.AnswerResponses.AddAsync(response);
            await _ctx.SaveChangesAsync();

            return response.Id;
        }
        #endregion

        #region update
        public async Task<AnsResponseDto> UpdateAsync(UpdateAnsResponseDto uard)
        {
            var response = _ctx.AnswerResponses.Find(uard.Id);

            response.Text = uard.Text;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<AnsResponseDto>(response);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.AnswerResponses.Remove(_ctx.AnswerResponses.Find(id));

            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
