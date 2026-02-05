using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailSliderComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ProductDetailSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/ProductImage/ProductImagesByProductId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
