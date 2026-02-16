using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.AboutServices;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            AboutViewBag();
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            AboutViewBag();
            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dtos)
        {
            await _aboutService.CreateAboutAsync(dtos);
            return RedirectToAction("Index", "About", new { area = "Admin" });

        }

        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index", "About", new { area = "Admin" });

        }

        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            AboutViewBag();
            var values = await _aboutService.GetByIdAboutAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dtos)
        {
            await _aboutService.UpdateAboutAsync(dtos);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        void AboutViewBag()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Abouts";
            ViewBag.v3 = "Abouts List";
            ViewBag.v0 = "Abouts Transaction";
        }

    }
        
}
