using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponent
{
    public class _FooterUILayoutViewComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FooterUILayoutViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44365/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
