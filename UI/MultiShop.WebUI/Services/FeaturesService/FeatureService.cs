using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.FeaturesService
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;
        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureDto>("feature", createFeatureDto);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync($"feature?id={id}");
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var response = await _httpClient.GetAsync("feature");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
        }

        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string id)
        {
            var response = await _httpClient.GetAsync($"feature/{id}");
            return await response.Content.ReadFromJsonAsync<UpdateFeatureDto>();
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("feature", updateFeatureDto);
        }
    }
}
