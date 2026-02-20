
namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCount()
        {
            var response = await _httpClient.GetAsync("Statistics/GetBrandCount");
            return await response.Content.ReadFromJsonAsync<long>();
        }

        public async Task<long> GetCategoryCount()
        {
            var response = await _httpClient.GetAsync("Statistics/GetCategoryCount");
            return await response.Content.ReadFromJsonAsync<long>();
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var response = await _httpClient.GetAsync("Statistics/GetProductAvgPrice");
            return await response.Content.ReadFromJsonAsync<decimal>();
        }

        public async Task<long> GetProductCount()
        {
            var response = await _httpClient.GetAsync("Statistics/GetProductCount");
            return await response.Content.ReadFromJsonAsync<long>();
        }

        public async Task<string> GetProductMaxPrice()
        {
            var response = await _httpClient.GetAsync("Statistics/GetProductMaxPrice");
            return await response.Content.ReadFromJsonAsync<string>();
        }

        public async Task<string> GetProductMinPrice()
        {
            var response = await _httpClient.GetAsync("Statistics/GetProductMinPrice");
            return await response.Content.ReadFromJsonAsync<string>();
        }
    }
}
