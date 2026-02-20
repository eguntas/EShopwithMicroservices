
using MultiShop.DtoLayer.IdentityDtos.UserDto;

namespace MultiShop.WebUI.Services.StatisticServices.UserStatisticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetUserCount()
        {
            var response = await _httpClient.GetAsync("https://localhost:5000/api/statistic");
            var users = await response.Content.ReadFromJsonAsync<int>();
            return users;
        }
    }
}
