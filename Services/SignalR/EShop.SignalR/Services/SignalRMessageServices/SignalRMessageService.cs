
namespace EShop.SignalR.Services.SignalRMessageServices
{
    public class SignalRMessageService: ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var response = await _httpClient.GetAsync($"message/GetTotalMessageCountByReceviverId?id={id}");
            var values = await response.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
