using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDtos createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDtos>("categories", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync($"categories?id={id}");
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var response = await _httpClient.GetAsync("categories");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        }

        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string id)
        {
            var response = await _httpClient.GetAsync($"categories/{id}");
            return await response.Content.ReadFromJsonAsync<UpdateCategoryDto>();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", updateCategoryDto);
        }
    }
}
