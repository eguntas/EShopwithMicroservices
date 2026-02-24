
using System.Net.Http;

namespace EShop.SignalR.Services
{
    public class SignalRService : ISignalRService
    {
        private readonly HttpClient _httpClient;

        public SignalRService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetTotalCommentCount()
        {
            var response = await _httpClient.GetAsync("message/GetTotalMessageCountAsync");
            var values = await response.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var response = await _httpClient.GetAsync($"message/GetTotalMessageCountByReceviverId?id={id}");
            var values = await response.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
