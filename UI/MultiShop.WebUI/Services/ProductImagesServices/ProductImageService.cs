using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.ProductImagesServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimage", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync($"productimage?id={id}");
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var response = await _httpClient.GetAsync("productimage");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var response = await _httpClient.GetAsync($"productimage/{id}");
            return await response.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
        }

        public async Task<GetByIdProductImageDto> GetByProductIdImageAsync(string id)
        {
            var response = await _httpClient.GetAsync($"productimage/ProductImagesByProductId/{id}");
            return await response.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productimage", updateProductImageDto);

        }
    }
}
