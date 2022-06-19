using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Topics;
using Rewinery.Shared.TopicGroup.Topic;
using Rewinery.Shared.TopicGroup.TopicPage;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8601, CS8602, CS8604, CS8620
    public class TopicRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public TopicRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<TopicDto> GetAsync(int id)
        {
            return _mapper.Map<TopicDto>(await _ctx.Topics
                .Include(x => x.User)
                .Include(x => x.Answers).ThenInclude(x => x.User)
                .Include(x => x.Answers).ThenInclude(x => x.AnswerResponces).ThenInclude(x => x.User)
                .FirstAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<ShortTopicDto>> GetAllShortAsync()
        {
            return _mapper.Map<IEnumerable<ShortTopicDto>>(await _ctx.Topics
                .Include(x => x.User).ToListAsync());
        }

        public async Task<IEnumerable<ShortTopicDto>> GetAllByUserNameAsync(string user)
        {
            return _mapper.Map<IEnumerable<ShortTopicDto>>(await _ctx.Topics
                .Include(x => x.User)
                .Where(x => x.User.UserName == user).ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateTopicDto ctd)
        {
            var topic = _mapper.Map<Topic>(ctd);

            topic.User = _ctx.Users.First(x => x.UserName == ctd.UserName);
            topic.Created = DateTime.Now;

            await _ctx.Topics.AddAsync(topic);
            await _ctx.SaveChangesAsync();

            return topic.Id;
        }
        #endregion

        #region update
        public async Task<TopicDto> UpdateAsync(UpdateTopicDto utd)
        {
            var topic = _ctx.Topics.Find(utd.Id);

            topic.Title = utd.Title;
            topic.Description = utd.Description;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<TopicDto>(topic);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.Topics.Remove(_ctx.Topics.Find(id));

            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
