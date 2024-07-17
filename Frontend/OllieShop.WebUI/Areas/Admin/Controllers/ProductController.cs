using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OllieShop.DtoLayer.CatalogDtos.Category;
using OllieShop.DtoLayer.CatalogDtos.Product;
using OllieShop.DtoLayer.CatalogDtos.ProductDetail;
using OllieShop.DtoLayer.CatalogDtos.ProductImage;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IApiService _apiService;

        public ProductController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _apiService.GetAsync<List<ResultProductsWithCategoryDto>>("https://localhost:7220/api/Products/ProductListWithCategory");
            return View(products);
        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _apiService.GetAsync<List<ResultCategoryDto>>("https://localhost:7220/api/Categories");
            List<SelectListItem> categoryValues = (from category in categories
                                                   select new SelectListItem
                                                   {
                                                       Text=category.Name,
                                                       Value=category.CategoryId
                                                   }).ToList();
            ViewBag.Categories = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var responseMessage = await _apiService.PostAsync("https://localhost:7220/api/Products", createProductDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var responseMessage = await _apiService.DeleteAsync($"https://localhost:7220/api/Products?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var product = await _apiService.GetAsync<UpdateProductDto>($"https://localhost:7220/api/Products/{id}");

            var categories = await _apiService.GetAsync<List<ResultCategoryDto>>("https://localhost:7220/api/Categories");
            List<SelectListItem> categoryValues = (from category in categories
                                                   select new SelectListItem
                                                   {
                                                       Text = category.Name,
                                                       Value = category.CategoryId
                                                   }).ToList();
            ViewBag.Categories = categoryValues;
            return View(product);
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var responseMessage = await _apiService.PutAsync("https://localhost:7220/api/Products", updateProductDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateProductImage/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            ViewBag.ProductId = id;
            var productImages = await _apiService.GetAsync<UpdateProductImageDto>($"https://localhost:7220/api/ProductImages/GetImagesByProductId?id={id}");
            if(productImages == null)
            {
                return Redirect($"/Admin/Product/AddProductImage/{id}");
            }
            return View(productImages);
        }

        [HttpPost]
        [Route("UpdateProductImage/{id}")]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var responseMessage = await _apiService.PutAsync("https://localhost:7220/api/ProductImages", updateProductImageDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }








        [Route("UpdateProductDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.ProductId = id;
            var productDetails = await _apiService.GetAsync<UpdateProductDetailDto>($"https://localhost:7220/api/ProductDetails/GetProductDetailsByProductId?id={id}");
            if (productDetails == null)
            {
                return Redirect($"/Admin/Product/Index");
            }
            return View(productDetails);
        }

        [HttpPost]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var responseMessage = await _apiService.PutAsync("https://localhost:7220/api/ProductDetails", updateProductDetailDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
