using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.OfferDiscountServices;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;
        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            OfferDiscountViewBag();
            var result = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(result);
 
        }

        [HttpGet]
        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountViewBag();
            return View();
        }

        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto dtos)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(dtos);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });


        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

        }

        [HttpGet]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountViewBag();
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(values);

        }

        [HttpPost]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto dtos)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(dtos);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

        }

        void OfferDiscountViewBag()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "OfferDiscount";
            ViewBag.v3 = "OfferDiscount List";
            ViewBag.v0 = "OfferDiscount Transaction";
        }
    }
}
