﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.GrapesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    public class GrapeRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public GrapeRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<GrapeReadDto> GetAsync(int id)
        {
            var obj = _mapper.Map<GrapeReadDto>(await _ctx.Grapes.FirstOrDefaultAsync(x => x.Id == id));
            return obj;
        }

        public async Task<IEnumerable<GrapeReadDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GrapeReadDto>>(await _ctx.Grapes.ToListAsync());
        }

        public async Task<string> CreateAsync(GrapeCreateDto grapeobj)
        {
            var newgrape = _mapper.Map<Grape>(grapeobj);
            await _ctx.Grapes.AddAsync(newgrape);
            await _ctx.SaveChangesAsync();
            return newgrape.Id.ToString();
        }

        public async Task DeleteAsync(int id)
        {
            _ctx.Grapes.Remove(_ctx.Grapes.Find(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(GrapeUpdateDto grapeobj)
        {
            var grape = _ctx.Grapes.Find(grapeobj.Id);
            grape.Name = grapeobj.Name;
            grape.Icon = grapeobj.Icon;
            grape.Price = grapeobj.Price;
            await _ctx.SaveChangesAsync();
        }

    }
}
