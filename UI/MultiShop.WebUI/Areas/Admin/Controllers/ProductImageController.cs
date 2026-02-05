using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       
        [HttpGet]
        [Route("ProductImageDetail/{id}")]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "New Product";
            ViewBag.v0 = "Product Transaction";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/ProductImage/ProductImagesByProductId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("ProductImageDetail/{id}")]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44365/api/ProductImage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
