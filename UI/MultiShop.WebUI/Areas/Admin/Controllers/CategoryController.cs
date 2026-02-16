using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            CategoryViewBagList();
            var result = await _categoryService.GetAllCategoryAsync();
            return View(result);
        }

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            
            CategoryViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDtos dtos)
        {
            await _categoryService.CreateCategoryAsync(dtos);
            return RedirectToAction("Index", "Category", new { area = "Admin" });

        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        
        }

        [HttpGet]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            CategoryViewBagList();
            var values = await _categoryService.GetByIdCategoryAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dtos)
        {
            await _categoryService.UpdateCategoryAsync(dtos);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
          
        }

        void CategoryViewBagList() 
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Categories List";
            ViewBag.v0 = "Categories Transaction";
        }
    }
}
