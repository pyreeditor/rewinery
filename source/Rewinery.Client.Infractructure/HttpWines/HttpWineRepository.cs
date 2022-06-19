using Rewinery.Shared.WineGroup.Wine;
using Rewinery.Shared.WineGroup.WineRecipePage;
using System.Net.Http.Json;

namespace Rewinery.Client.Infrastructure.HttpWines
{
#pragma warning disable CS8603
    public class HttpWineRepository : HttpBaseRepository
    {
        public HttpWineRepository(HttpClient httpClient) : base(httpClient) { }

        #region get
        /// <summary>
        /// Method for obtaining information from the API about one wine by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Wine object with detailed information</returns>
        public async Task<WineDto> GetAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<WineDto>($"/api/wines/{id}");
        }

        /// <summary>
        /// Method for obtaining a list of wines with abbreviated information from the API
        /// </summary>
        /// <returns>List of wines with short information</returns>
        public async Task<IEnumerable<ShortWineDto>> GetAllShortAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ShortWineDto>>($"/api/wines/short");
        }

        /// <summary>
        /// Method for obtaining a list of wines with abbreviated information from the API for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>List of wines with short information, belonging to a specific user</returns>
        public async Task<IEnumerable<ShortWineDto>> GetByUserNameAsync(string user)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ShortWineDto>>($"/api/wines/short/{user}");
        }
        #endregion

        #region create
        public async Task CreateAsync(CreateWineDto wine)
        {
            await _httpClient.PostAsJsonAsync($"/api/wines", wine);
        }
        #endregion

        #region update
        public async Task UpdateAsync(UpdateWineDto wine)
        {
            await _httpClient.PutAsJsonAsync($"/api/wines", wine);
        }
        #endregion

        #region delete
        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync($"/api/wines{id}");
        }
        #endregion
    }
}
