using Eshop.Category.Dtos.ProductDtos;
using Eshop.Category.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        [HttpGet]
        public async Task<IActionResult> productList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createproductDto)
        {
            await _productService.CreateProductAsync(createproductDto);
            return Ok("Added product success!!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Deleted product success");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateproductDto)
        {
            await _productService.UpdateProductAsync(updateproductDto);
            return Ok("Updated product success");
        }

    }
}
