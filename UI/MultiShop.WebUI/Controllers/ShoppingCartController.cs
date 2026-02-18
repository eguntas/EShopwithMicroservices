using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public async Task<IActionResult> Index(string code , int discountRate ,decimal discountPrice)
        {
            ViewBag.Directory1 = "Home";
            ViewBag.Directory2 = "Product";
            ViewBag.Directory3 = "Shopping Card";
            var total = await _basketService.GetBasket();
            var tax = total.TotalPrice > 0 ? total.TotalPrice/10 : 0;
            ViewBag.Price = total.TotalPrice;
            ViewBag.Tax = tax;
            ViewBag.Total = total.TotalPrice + tax;
            ViewBag.Rate = discountRate;
            ViewBag.DiscountPrice = discountPrice;

            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var product = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = product.ProductID,
                ProductName = product.ProductName,
                Price = product.ProductPrice,
                Quantity = 1,
                ProductImageUrl = product.ProductImageUrl
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
