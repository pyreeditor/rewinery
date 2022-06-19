using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.OrderGroup.Orders;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository) => _orderRepository = orderRepository;

        #region get
        [HttpGet]
        [Route("/api/order/{id}")]
        public async Task<OrderDto> GetAsync(int id)
        {
            return await _orderRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateOrderDto order)
        {
            return await _orderRepository.CreateAsync(order);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<OrderDto> UpdateAsync(UpdateOrderDto order)
        {
            return await _orderRepository.UpdateAsync(order);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/order/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _orderRepository.DeleteAsync(id);
        }
        #endregion
    }
}
