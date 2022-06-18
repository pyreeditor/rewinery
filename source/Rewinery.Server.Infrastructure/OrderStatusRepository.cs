using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Orders;
using Rewinery.Shared.OrderGroup.OrderStatusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Infrastructure
{
    public class OrderStatusRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public OrderStatusRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<OrderStatusReadDto> GetAsync(int id)
        {
            return _mapper.Map<OrderStatusReadDto>(await _ctx.OrderStatuses
                .FirstOrDefaultAsync(x => x.Id == id));
        }
        public async Task<IEnumerable<OrderStatusReadDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<OrderStatusReadDto>>(await _ctx.OrderStatuses
                .ToListAsync());
        }
        public async Task DeleteAsync(int id)
        {
            _ctx.OrderStatuses.Remove(_ctx.OrderStatuses.Find(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(OrderStatusCreateDto createDto)
        {
            var nOrderStatus = _mapper.Map<OrderStatus>(createDto);
            nOrderStatus.Status = createDto.Status;
            await _ctx.OrderStatuses.AddAsync(nOrderStatus);
            await _ctx.SaveChangesAsync();
            return nOrderStatus.Id;
        }
    }
}
