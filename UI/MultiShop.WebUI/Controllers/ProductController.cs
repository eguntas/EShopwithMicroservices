using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.CategoryId = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.ProductId = id;
            return View();
        }
    }
}
