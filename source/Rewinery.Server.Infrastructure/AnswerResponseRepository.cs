using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Topics;
using Rewinery.Shared.TopicGroup.AnswerResponsesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    public class AnswerResponseRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public AnswerResponseRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<AnswerResponseReadDto> GetAsync(int id)
        {
            return _mapper.Map<AnswerResponseReadDto>(await _ctx.AnswerResponses
                .Include(x=>x.User)
                .FirstOrDefaultAsync(x => x.Id == id));
        }
        public async Task DeleteAsync(int id)
        {
            _ctx.AnswerResponses.Remove(_ctx.AnswerResponses.Find(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(AnswerResponseCreateDto answerResponseDto)
        {
            var nAnswerResponse = _mapper.Map<AnswerResponse>(answerResponseDto);
            nAnswerResponse.Created = DateTime.Now;
            nAnswerResponse.ResponseText = answerResponseDto.ResponseText;
            nAnswerResponse.Answer = _ctx.Answers.Find(answerResponseDto.AnswerId);
            nAnswerResponse.User = _ctx.Users.FirstOrDefault(x=>x.UserName == answerResponseDto.OwnerUserName);
            await _ctx.AnswerResponses.AddAsync(nAnswerResponse);
            await _ctx.SaveChangesAsync();
            return nAnswerResponse.Id;
        }
    }
}
