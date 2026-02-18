using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;
        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetDiscountByCode> GetDiscountByCode(string code)
        {
            var response = await _httpClient.GetAsync($"discount/GetCodeDetailByCode/{code}");
            var values = await response.Content.ReadFromJsonAsync<GetDiscountByCode>();
            return values;
        }
    }
}
