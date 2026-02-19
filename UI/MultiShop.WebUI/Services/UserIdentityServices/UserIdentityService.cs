using MultiShop.DtoLayer.IdentityDtos.UserDto;

namespace MultiShop.WebUI.Services.UserIdentityServices
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;

        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDto>> GetAllUser()
        {
            var response = await _httpClient.GetAsync("api/users/GetAllUserList");
            var users = await response.Content.ReadFromJsonAsync<List<ResultUserDto>>();
            return users ?? new List<ResultUserDto>();
        }
    }
}
