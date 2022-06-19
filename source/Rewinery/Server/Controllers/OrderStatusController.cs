using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.OrderGroup.OrderStatus;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/orderstatus")]
    public class OrderStatusController : Controller
    {
        private readonly OrderStatusRepository _orderStatusRepository;

        public OrderStatusController(OrderStatusRepository orderStatusRepository) => _orderStatusRepository = orderStatusRepository;

        #region get
        [HttpGet]
        [Route("/api/orderstatus/{id}")]
        public async Task<OrderStatusDto> GetAsync(int id)
        {
            return await _orderStatusRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderStatusDto>> GetAllAsync()
        {
            return await _orderStatusRepository.GetAllAsync();
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateOrderStatusDto status)
        {
            return await _orderStatusRepository.CreateAsync(status);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<OrderStatusDto> UpdateAsync(OrderStatusDto status)
        {
            return await _orderStatusRepository.UpdateAsync(status);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/orderstatus/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _orderStatusRepository.DeleteAsync(id);
        }
        #endregion
    }
}
