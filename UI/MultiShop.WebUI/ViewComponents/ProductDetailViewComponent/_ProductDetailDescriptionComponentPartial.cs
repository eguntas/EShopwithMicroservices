using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.ProductDetailServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailDescriptionComponentPartial:ViewComponent
    {
        
        private readonly IProductDetailService _productDetailService;
        public _ProductDetailDescriptionComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productDetail = await _productDetailService.GetByIdProductIdProductDetailAsync(id);
            return View(productDetail);

          
        }
    }
}
