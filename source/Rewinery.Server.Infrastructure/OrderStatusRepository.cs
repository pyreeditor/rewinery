using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Orders;
using Rewinery.Shared.OrderGroup.OrderStatus;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8601, CS8602, CS8604, CS8620
    public class OrderStatusRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public OrderStatusRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<OrderStatusDto> GetAsync(int id)
        {
            return _mapper.Map<OrderStatusDto>(await _ctx.OrderStatuses.FindAsync(id));
        }

        public async Task<IEnumerable<OrderStatusDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<OrderStatusDto>>(await _ctx.OrderStatuses.ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateOrderStatusDto cosd)
        {
            var status = _mapper.Map<OrderStatus>(cosd);

            await _ctx.OrderStatuses.AddAsync(status);
            await _ctx.SaveChangesAsync();

            return status.Id;
        }
        #endregion

        #region update
        public async Task<OrderStatusDto> UpdateAsync(OrderStatusDto uosd)
        {
            var status = _ctx.OrderStatuses.Find(uosd.Id).Status = uosd.Status;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<OrderStatusDto>(status);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.OrderStatuses.Remove(_ctx.OrderStatuses.Find(id));

            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
