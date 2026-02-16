using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
        {
            var response = await _httpClient.GetAsync("Comment/CommentListByProductId/{id}");
            var result = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(result);
            return values;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCommentDto>("Comment", createCommentDto);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _httpClient.DeleteAsync($"Comment?id={id}");

        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var response = await _httpClient.GetAsync("Comment");
            var brands = await response.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return brands ?? new List<ResultCommentDto>();
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
        {
            var response = await _httpClient.GetAsync($"Comment/{id}");
            var brand = await response.Content.ReadFromJsonAsync<UpdateCommentDto>();
            return brand ?? new UpdateCommentDto();
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCommentDto>("Comment", updateCommentDto);
        }

        
    }
}
