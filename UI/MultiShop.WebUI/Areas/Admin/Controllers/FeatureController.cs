using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.FeaturesService;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureViewBag();
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:44365/api/Feature");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
            //    return View(values);
            //}

            //return View();
        }

        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            FeatureViewBag();
            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dtos)
        {

            await _featureService.CreateFeatureAsync(dtos);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });

            //var client = _httpClientFactory.CreateClient();
            //var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dtos);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("https://localhost:44365/api/Feature", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Feature", new { area = "Admin" });
            //}
            //return View();
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"https://localhost:44365/api/Feature?id={id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Feature", new { area = "Admin" });
            //}
            //return View();
        }

        [HttpGet]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            FeatureViewBag();
            var values = await _featureService.GetByIdFeatureAsync(id);
            return View(values);

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"https://localhost:44365/api/Feature/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
            //    return View(values);
            //}
            //return View();
        }

        [HttpPost]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dtos)
        {
            await _featureService.UpdateFeatureAsync(dtos);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });

            //var client = _httpClientFactory.CreateClient();
            //var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dtos);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("https://localhost:44365/api/Feature/", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Feature", new { area = "Admin" });
            //}
            //return View();
        }

        void FeatureViewBag()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Feature";
            ViewBag.v3 = "New Feature";
            ViewBag.v0 = "Feature Transaction";
        }
    }
}
