using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponent
{
    public class _CategoryDefaultComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public _CategoryDefaultComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
