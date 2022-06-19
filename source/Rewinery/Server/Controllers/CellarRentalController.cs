using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.CellarGroup.Rental;

namespace Rewinery.Server.Controllers
{
    [ApiController]
    [Route("api/cellarrental")]
    public class CellarRentalController : Controller
    {
        private readonly CellarRentalRepository _cellarRentalRepository;

        public CellarRentalController(CellarRentalRepository cellarRentalRepository) => _cellarRentalRepository = cellarRentalRepository;

        #region get
        [HttpGet]
        [Route("/api/cellarrental/{id}")]
        public async Task<CellarRentalDto> GetAsync(int id)
        {
            return await _cellarRentalRepository.GetAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<CellarRentalDto>> GetListAsync()
        {
            return await _cellarRentalRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("/api/cellarrental/{user}")]
        public async Task<IEnumerable<CellarRentalDto>> GetAllByUserNameAsync(string user)
        {
            return await _cellarRentalRepository.GetAllByUserNameAsync(user);
        }
        #endregion

        #region create
        [HttpPost]
        public async Task<int> CreateAsync(CreateCellarRentalDto rental)
        {
            return await _cellarRentalRepository.CreateAsync(rental);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<CellarRentalDto> UpdateAsync(UpdateCellarRentalDto rental)
        {
            return await _cellarRentalRepository.UpdateAsync(rental);
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("/api/cellarrental/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _cellarRentalRepository.DeleteAsync(id);
        }
        #endregion
    }
}
