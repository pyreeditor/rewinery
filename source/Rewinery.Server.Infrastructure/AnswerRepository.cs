using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Topics;
using Rewinery.Shared.TopicGroup.AnswersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    public class AnswerRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public AnswerRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<AnswerReadDto> GetAsync(int id)
        {
            return _mapper.Map<AnswerReadDto>( await _ctx.Answers
                .Include(x=>x.AnswerResponces).ThenInclude(x=>x.User)
                .Include(x=>x.User)
                .FirstOrDefaultAsync(x=>x.Id == id));
        }

        public async Task<IEnumerable<AnswerReadDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AnswerReadDto>>(await _ctx.Answers
                .Include(x => x.AnswerResponces)
                .Include(x => x.User)
                .ToListAsync());
        }

        public async Task DeleteAsync(int id)
        {
            _ctx.Answers.Remove(_ctx.Answers.Find(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(AnswerCreateDto answerDto)
        {
            var nAnswer = _mapper.Map<Answer>(answerDto);
            nAnswer.Created = DateTime.Now;
            nAnswer.Topic = _ctx.Topics.Find(answerDto.TopicId);
            nAnswer.User = _ctx.Users.FirstOrDefault(x=>x.UserName == answerDto.OwnerUserName);
            nAnswer.AnswerText = answerDto.AnswerText;
            await _ctx.Answers.AddAsync(nAnswer);
            await _ctx.SaveChangesAsync();
            return nAnswer.Id;
        }
    }
}
