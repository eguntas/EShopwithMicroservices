using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;
        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDto>("about", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync($"about?id={id}");

        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var response = await _httpClient.GetAsync("about");
            var brands = await response.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
            return brands ?? new List<ResultAboutDto>();
        }

        public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
        {
            var response = await _httpClient.GetAsync($"about/{id}");
            var brand = await response.Content.ReadFromJsonAsync<UpdateAboutDto>();
            return brand ?? new UpdateAboutDto();
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDto>("about", updateAboutDto);
        }
    }
}
