using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.ViewComponents.ProductViewComponents
{
    public class _ProductComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ProductComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/Product/ProductListWithCategoryByCategoryId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
