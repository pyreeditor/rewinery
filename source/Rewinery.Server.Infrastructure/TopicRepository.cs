using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Topics;
using Rewinery.Shared.TopicGroup.TopicsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    public class TopicRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public TopicRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        //public async Task<TopicListPageDto> GetTopicListPageItemAsync(int id)
        //{
        //    return _mapper.Map<TopicListPageDto>(await _ctx.Topics
        //        .Include(x => x.User)
        //        .FirstOrDefaultAsync(x => x.Id == id));
        //}
        public async Task<IEnumerable<ShortTopicInfoDto>> GetAllShortTopicInfoAsync()
        {
            return _mapper.Map<IEnumerable<ShortTopicInfoDto>>(await _ctx.Topics
                .Include(x => x.User)
                .ToListAsync());
        }

        public async Task<TopicPageDto> GetTopicPageAsync(int id)
        {
            
            return _mapper.Map<TopicPageDto>(await _ctx.Topics
                .Include(x => x.Answers).ThenInclude(x=>x.AnswerResponces).ThenInclude(x => x.User)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<TopicPageDto>> GetAllTopicPageAsync()
        {
            return _mapper.Map<IEnumerable<TopicPageDto>>(await _ctx.Topics
                .Include(x => x.Answers).ThenInclude(x => x.AnswerResponces).ThenInclude(x => x.User)
                .Include(x => x.User)
                .ToListAsync());
        }

        public async Task DeleteAsync(int id)
        {
            _ctx.Topics.Remove(_ctx.Topics.Find(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(TopicCreateDto topicCreateDto)
        {
            var nTopic = _mapper.Map<Topic>(topicCreateDto);
            nTopic.Created = DateTime.Now;
            nTopic.Description = topicCreateDto.Description;
            nTopic.Title = topicCreateDto.Title;
            nTopic.User = _ctx.Users.FirstOrDefault(x => x.UserName == topicCreateDto.OwnerUserName);
            await _ctx.Topics.AddAsync(nTopic);
            await _ctx.SaveChangesAsync();
            return nTopic.Id;
        }

        public async Task<int> UpdateAsync(TopicUpdateDto updateDto)
        {
            var topic = _ctx.Topics.Find(updateDto.Id);
            topic.Description = updateDto.Description;
            topic.Title = updateDto.Title;
            await _ctx.SaveChangesAsync();
            return topic.Id;
        }
    }
}
