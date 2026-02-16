using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.BrandsService
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDto>("brand", createBrandDto);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync($"brand?id={id}");
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var response = await _httpClient.GetAsync("brand");
            var brands = await response.Content.ReadFromJsonAsync<List<ResultBrandDto>>();
            return brands ?? new List<ResultBrandDto>();
        }

        public async Task<UpdateBrandDto> GetByIdBrandAsync(string id)
        {
           var response = await _httpClient.GetAsync($"brand/{id}");
           var brand = await response.Content.ReadFromJsonAsync<UpdateBrandDto>();
           return brand ?? new UpdateBrandDto();
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDto>("brand", updateBrandDto);
        }
    }
}
