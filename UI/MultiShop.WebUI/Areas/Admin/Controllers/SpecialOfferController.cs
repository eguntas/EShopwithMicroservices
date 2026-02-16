using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.SpecialOfferServices;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;
        public SpecialOfferController(ISpecialOfferService specialOfferService = null)
        {
            _specialOfferService = specialOfferService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            
            SpecialOfferViewBag();
            var values = await _specialOfferService.GetAllSpecialOfferAsync();

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:44365/api/SpecialOffer");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
            //    return View(values);
            //}

            return View(values);
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
          
            SpecialOfferViewBag();

            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto dtos)
        {
            await _specialOfferService.CreateSpecialOfferAsync(dtos);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

            //var client = _httpClientFactory.CreateClient();
            //var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dtos);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("https://localhost:44365/api/SpecialOffer", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            //}
            //return View();
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });


            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"https://localhost:44365/api/SpecialOffer?id={id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            //}
            //return View();
        }

        [HttpGet]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
         
            SpecialOfferViewBag();
            var values = _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(values);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync($"https://localhost:44365/api/SpecialOffer/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
            //    return View(values);
            //}
            //return View();
        }

        [HttpPost]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto dto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(dto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

            //var client = _httpClientFactory.CreateClient();
            //var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("https://localhost:44365/api/SpecialOffer/", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            //}
            //return View();
        }

        void SpecialOfferViewBag()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Special Offer";
            ViewBag.v3 = "Special Offer List";
            ViewBag.v0 = "Special Offer Transaction";
        }
    }
}
