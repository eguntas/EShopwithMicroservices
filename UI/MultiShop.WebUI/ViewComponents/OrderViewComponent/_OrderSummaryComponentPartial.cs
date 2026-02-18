using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponent
{
    public class _OrderSummaryComponentPartial:ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> Invoke()
        {
            var basket = await _basketService.GetBasket();
            var basketItems = basket.BasketItems;
            return View(basketItems);
        }
    }
}
