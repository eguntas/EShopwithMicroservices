using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.FeatureSliderServices;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    [AllowAnonymous]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureSliderService _featureSliderService;
        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureSliderViewBag();

            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:44365/api/FeatureSliders");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
            //    return View(values);
            //}

            //return View();
        }

        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            FeatureSliderViewBag();
            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto dto)
        {
            dto.Status = false;

            await _featureSliderService.CreateFeatureSliderAsync(dto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

            //var client = _httpClientFactory.CreateClient();
            //var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("https://localhost:44365/api/FeatureSliders", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            //}
            //return View();
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {

            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"https://localhost:44365/api/FeatureSliders?id={id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            //}
            //return View();
        }

        [HttpGet]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            FeatureSliderViewBag();
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(values);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"https://localhost:44365/api/FeatureSliders/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
            //    return View(values);
            //}
            //return View();
        }

        [HttpPost]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto dto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(dto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });


            //var client = _httpClientFactory.CreateClient();
            //var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("https://localhost:44365/api/FeatureSliders/", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            //}
            //return View();
        }

        void FeatureSliderViewBag() 
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Feature Slider Image";
            ViewBag.v3 = "Feature Slider Image List";
            ViewBag.v0 = "Feature Slider Transaction";
        }
    }
}
