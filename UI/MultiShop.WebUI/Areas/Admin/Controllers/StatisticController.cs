using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.DiscountServices;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentService _commentService;
        private readonly IDiscountService _discountService;
        private readonly IMessageService _messageService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentService commentService, IDiscountService discountService , IMessageService messageService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentService = commentService;
            _discountService = discountService;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var brandCount = _catalogStatisticService.GetBrandCount();
            var productCount = _catalogStatisticService.GetProductCount();
            var categoryCount = _catalogStatisticService.GetCategoryCount();
            //var avgPrice = _catalogStatisticService.GetProductAvgPrice();
            var maxPrice = _catalogStatisticService.GetProductMaxPrice();
            var minPrice = _catalogStatisticService.GetProductMinPrice();
            var userCount = _userStatisticService.GetUserCount();

            var totalComment = _commentService.GetTotalCommentCountAsync();
            var activeComment = _commentService.GetActiveCommentCountAsync();
            var passiveComment = _commentService.GetPassiveCommentCountAsync();

            var couponCount = _discountService.GetDiscountCouponCount();

            var messageCount = _messageService.GetTotalMessageCountAsync();

            ViewBag.brandCount = brandCount;  
            ViewBag.categoryCount = categoryCount;
            //ViewBag.avgPrice = avgPrice;
            ViewBag.maxPrice = maxPrice;
            ViewBag.minPrice = minPrice;
            ViewBag.productCount = productCount;
            ViewBag.userCount = userCount;

            ViewBag.totalComment = totalComment;
            ViewBag.activeComment = activeComment;
            ViewBag.passiveComment = passiveComment;

            ViewBag.couponCount = couponCount;

            ViewBag.messageCount = messageCount;




            return View();
        }
    }
}
