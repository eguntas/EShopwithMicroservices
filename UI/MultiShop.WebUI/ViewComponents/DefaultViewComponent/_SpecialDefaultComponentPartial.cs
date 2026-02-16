using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.SpecialOfferServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponent
{
    public class _SpecialDefaultComponentPartial:ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;
        public _SpecialDefaultComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
    }
}
