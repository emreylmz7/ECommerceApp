using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OllieShop.DtoLayer.CatalogDtos.Product;
using OllieShop.DtoLayer.CatalogDtos.ProductDetail;
using OllieShop.DtoLayer.CatalogDtos.ProductImage;
using OllieShop.WebUI.Services.CatalogServices.CategoryServices;
using OllieShop.WebUI.Services.CatalogServices.ProductDetailServices;
using OllieShop.WebUI.Services.CatalogServices.ProductImageServices;
using OllieShop.WebUI.Services.CatalogServices.ProductServices;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductDetailService _productDetailService;
        private readonly IProductImageService _productImageService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, IProductDetailService productDetailService, IProductImageService productImageService, ICategoryService categoryService)
        {
            _productService = productService;
            _productDetailService = productDetailService;
            _productImageService = productImageService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var productStatistics = await _productService.GetProductsStatistics();
            var products = (await _productService.GetAllProductsWithCategoryAsync())
                                .OrderByDescending(p => p.ProductId)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            var totalProductCount = productStatistics.TotalProductCount;

            ViewBag.TotalPages = (int)Math.Ceiling(totalProductCount / (double)pageSize);
            ViewBag.CurrentPage = pageNumber;

            ViewBag.One = "Total Products";
            ViewBag.OneDesc = productStatistics.TotalProductCount.ToString();
            ViewBag.OneIcon = "bx bx-package bx-lg text-success p-3";

            ViewBag.Two = "Avg Price";
            ViewBag.TwoDesc = productStatistics.AverageProductPrice.ToString("C");
            ViewBag.TwoIcon = "bx bx-dollar bx-lg text-info p-3";

            ViewBag.Three = "Top Category";
            ViewBag.ThreeDesc = productStatistics.CategoryWithMostProducts ?? "N/A";
            ViewBag.ThreeIcon = "bx bx-category-alt bx-lg text-warning p-3";

            ViewBag.Four = "Top Product";
            ViewBag.FourDesc = productStatistics.MostExpensiveProductName ?? "N/A";
            ViewBag.FourIcon = "bx bx-crown bx-lg text-primary p-3";

            return View(products);
        }



        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from category in categories
                                                   select new SelectListItem
                                                   {
                                                       Text = category.Name,
                                                       Value = category.CategoryId
                                                   }).ToList();
            ViewBag.Categories = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var responseMessage = await _productService.CreateProductAsync(createProductDto);
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
            var responseMessage = await _productService.DeleteProductAsync(id);
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
            var product = await _productService.GetByIdProductAsync(id);
            var product2 = new UpdateProductDto
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Price = product.Price,
                ProductId = product.ProductId,
            };

            var categories = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from category in categories
                                                   select new SelectListItem
                                                   {
                                                       Text = category.Name,
                                                       Value = category.CategoryId
                                                   }).ToList();
            ViewBag.Categories = categoryValues;
            return View(product2);
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var responseMessage = await _productService.UpdateProductAsync(updateProductDto);
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
            var productImages = await _productImageService.GetProductImagesByProductId(id);
            if (productImages == null)
            {
                return Redirect($"/Admin/Product/AddProductImage/{id}");
            }
            return View(productImages);
        }

        [HttpPost]
        [Route("UpdateProductImage/{id}")]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            //var responseMessage = await _apiService.PutAsync("https://localhost:7220/api/ProductImages", updateProductImageDto);
            var responseMessage = await _productImageService.UpdateProductImageAsync(updateProductImageDto);
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
            var productDetails = await _productDetailService.GetProductDetailsByProductId(id);
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
            var responseMessage = await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
