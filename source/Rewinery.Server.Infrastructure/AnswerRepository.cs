using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Topics;
using Rewinery.Shared.TopicGroup.Answer;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8601, CS8602, CS8604, CS8620
    public class AnswerRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public AnswerRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<AnswerDto> GetAsync(int id)
        {
            return _mapper.Map<AnswerDto>( await _ctx.Answers
                .Include(x=>x.AnswerResponces).ThenInclude(x=>x.User)
                .Include(x=>x.User)
                .FirstOrDefaultAsync(x=>x.Id == id));
        }

        public async Task<IEnumerable<AnswerDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AnswerDto>>(await _ctx.Answers
                .Include(x => x.AnswerResponces)
                .Include(x => x.User)
                .ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateAnswerDto cad)
        {
            var answer = _mapper.Map<Answer>(cad);

            answer.User = _ctx.Users.First(x => x.UserName == cad.UserName);
            answer.Topic = _ctx.Topics.Find(cad.TopicId);
            answer.Created = DateTime.Now;

            await _ctx.Answers.AddAsync(answer);
            await _ctx.SaveChangesAsync();

            return answer.Id;
        }
        #endregion

        #region update
        public async Task<AnswerDto> UpdateAsync(UpdateAnswerDto uad)
        {
            var answer = _ctx.Answers.Find(uad.Id);

            answer.Text = uad.Text;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<AnswerDto>(answer);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.Answers.Remove(_ctx.Answers.Find(id));

            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
