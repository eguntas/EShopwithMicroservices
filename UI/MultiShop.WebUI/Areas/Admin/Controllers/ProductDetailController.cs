using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       

        [HttpGet]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Product Detail Update Page";
            ViewBag.v0 = "Product Detail Transaction";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/ProductDetail/GetProductDetailByProductId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto dtos)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dtos);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44365/api/ProductDetail/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
