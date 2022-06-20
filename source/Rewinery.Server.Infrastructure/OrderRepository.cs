using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models.Orders;
using Rewinery.Shared.OrderGroup.Orders;

namespace Rewinery.Server.Infrastructure
{
    #pragma warning disable CS8601, CS8602, CS8604, CS8620
    public class OrderRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public OrderRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        #region get
        public async Task<OrderDto> GetAsync(int id)
        {
            return _mapper.Map<OrderDto>(await _ctx.Orders
                .Include(x => x.User)
                .Include(x => x.Wine).ThenInclude(x => x.Grape)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Wine).ThenInclude(x => x.Ingredients)
                .Include(x => x.Status)
                .FirstAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<OrderDto>>(await _ctx.Orders
                .Include(x => x.User)
                .Include(x => x.Wine).ThenInclude(x => x.Grape)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Wine).ThenInclude(x => x.Ingredients)
                .Include(x => x.Status)
                .ToListAsync());
        }

        public async Task<IEnumerable<OrderDto>> GetAllByUserNameAsync(string user)
        {
            return _mapper.Map<IEnumerable<OrderDto>>(await _ctx.Orders
                .Include(x => x.User)
                .Include(x => x.Wine).ThenInclude(x => x.Grape)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Category)
                .Include(x => x.Wine).ThenInclude(x => x.Grape).ThenInclude(x => x.Subcategory)
                .Include(x => x.Wine).ThenInclude(x => x.Ingredients)
                .Include(x => x.Status)
                .Where(x => x.User.UserName == user)
                .ToListAsync());
        }
        #endregion

        #region create
        public async Task<int> CreateAsync(CreateOrderDto cod)
        {
            var order = _mapper.Map<Order>(cod);

            order.User = _ctx.Users.First(x => x.UserName == cod.UserName);
            order.Wine = _ctx.Wines.Find(cod.WineId);
            order.Status = _ctx.OrderStatuses.Find(cod.StatusId);

            await _ctx.Orders.AddAsync(order);
            await _ctx.SaveChangesAsync();

            return order.Id;
        }
        #endregion

        #region update
        public async Task<OrderDto> UpdateAsync(UpdateOrderDto uod)
        {
            var order = _ctx.Orders.Find(uod.Id);

            order.Status = _ctx.OrderStatuses.Find(uod.StatusId);

            await _ctx.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }
        #endregion

        #region delete
        public async Task<int> DeleteAsync(int id)
        {
            _ctx.Orders.Remove(_ctx.Orders.Find(id));

            await _ctx.SaveChangesAsync();

            return 200;
        }
        #endregion
    }
}
