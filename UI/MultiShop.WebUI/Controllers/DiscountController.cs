using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;


        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public PartialViewResult ConfirmDiscountCode()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCode(string code)
        {
            var result = await _discountService.GetDiscountByCode(code);
            var basketValues = await _basketService.GetBasket();
            var totalPriceWithTax = basketValues.TotalPrice + (basketValues.TotalPrice / 10);
            var discountAmount = totalPriceWithTax * result.Rate / 100;
            var discountedPrice = totalPriceWithTax - discountAmount;
            return RedirectToAction("Index", "ShoppingCart", new { code = code , discountRate = result.Rate , discountPrice = discountedPrice });
          
        }
    }
}
