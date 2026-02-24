
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace EShop.SignalR.Services.SignalRCommentServices
{
    public class SignalRCommentService:ISignalRCommentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRCommentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http:/localhost:7005/api/CommentStatistics");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(jsonData);
        }

       
    }
}
