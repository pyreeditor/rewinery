namespace Rewinery.Client.Infrastructure
{
    public class HttpBaseRepository
    {
        protected readonly HttpClient _httpClient;
        public HttpBaseRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}