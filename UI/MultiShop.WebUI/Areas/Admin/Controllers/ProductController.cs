using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices;
using MultiShop.WebUI.Services.ProductServices;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IHttpClientFactory httpClientFactory, IProductService productService = null, ICategoryService categoryService = null)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewBag();
            var values = await _productService.GetAllProductAsync();
            return View(values);

        }


        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductViewBag();
            //var categoryList = await _categoryService.GetAllCategoryAsync();


            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:44365/api/Product/ProductListWithCategory");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //    return View(values);
            //}

            return View();
        }

        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
      
            ProductViewBag();
            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
          
            await _productService.CreateProductAsync(dto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
          
        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewBag();
            var categoryList = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in categoryList
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            var productValues = await _productService.GetByIdProductAsync(id);

          
            return View(productValues);
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dtos)
        {
            
            await _productService.UpdateProductAsync(dtos);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        void ProductViewBag()
        {
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "Products List";
            ViewBag.v0 = "Products Transaction";
        }
    }
}
