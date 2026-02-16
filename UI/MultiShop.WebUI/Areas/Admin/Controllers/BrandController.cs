using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.BrandsService;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {

        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService = null)
        {
            _brandService = brandService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            BrandViewBag();
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            BrandViewBag();

            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto dtos)
        {
            await _brandService.CreateBrandAsync(dtos);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });

        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });

        }

        [HttpGet]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            BrandViewBag();
            var values = await _brandService.GetByIdBrandAsync(id);
            return View(values);

        }

        [HttpPost]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto dtos)
        {
            await _brandService.UpdateBrandAsync(dtos);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });

        }

        void BrandViewBag()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Brands";
            ViewBag.v3 = "Brands List";
            ViewBag.v0 = "Brands Transaction";
        }
    }
}
