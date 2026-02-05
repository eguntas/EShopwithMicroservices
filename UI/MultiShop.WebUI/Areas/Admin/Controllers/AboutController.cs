using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Abouts";
            ViewBag.v3 = "Abouts List";
            ViewBag.v0 = "Abouts Transaction";

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

        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Abouts";
            ViewBag.v3 = "Abouts List";
            ViewBag.v0 = "Abouts Transaction";
            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dtos)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dtos);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44365/api/About", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44365/api/About?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Abouts";
            ViewBag.v3 = "Abouts List";
            ViewBag.v0 = "Abouts Transaction";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44365/api/About/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dtos)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dtos);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44365/api/About/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }
    }
        
}
