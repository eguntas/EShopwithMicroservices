using Eshop.Category.Dtos.ProductDetailDtos;
using Eshop.ProductDetail.Services.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Category.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var values = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Added ProductDetail success!!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Deleted ProductDetail success");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Updated ProductDetail success");
        }
    }
}
