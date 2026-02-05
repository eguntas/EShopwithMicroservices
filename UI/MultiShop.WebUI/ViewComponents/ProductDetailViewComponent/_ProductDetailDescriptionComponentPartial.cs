using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailDescriptionComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ProductDetailDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
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
    }
}
