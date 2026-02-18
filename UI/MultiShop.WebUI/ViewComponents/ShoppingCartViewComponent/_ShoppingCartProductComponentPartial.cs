using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponent
{
    public class _ShoppingCartProductComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartProductComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = await _basketService.GetBasket();
            var items = basket.BasketItems;
            return View(items);
        }
    }

}
