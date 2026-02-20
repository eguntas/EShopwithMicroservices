using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var response = await _httpClient.GetAsync($"message/GetMessageInbox?id={id}");
            var values = await response.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
            return values;
        }

        public async Task<List<ResultISendboxMessageDto>> GetSandboxMessageAsync(string id)
        {
            var response = await _httpClient.GetAsync($"message/GetMessageSendbox?id={id}");
            var values = await response.Content.ReadFromJsonAsync<List<ResultISendboxMessageDto>>();
            return values;
        }
        
        public async Task<int> GetTotalMessageCountAsync()
        {
            var response = await _httpClient.GetAsync("message/GetTotalMessageCountAsync");
            var values = await response.Content.ReadFromJsonAsync<int>();
            return values;
        }

    }
}
