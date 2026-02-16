using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("product", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync($"product?id={id}");
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var response = await _httpClient.GetAsync("product");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string id)
        {
            var response = await _httpClient.GetAsync($"product/{id}");
            return await response.Content.ReadFromJsonAsync<UpdateProductDto>();

        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var response = await _httpClient.GetAsync("product");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId)
        {
            var response = await _httpClient.GetAsync($"product/ProductListWithCategoryByCategoryId/{CategoryId}");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("product", updateProductDto);
        }
    }
}
