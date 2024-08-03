using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OllieShop.DtoLayer.CommentDtos;
using OllieShop.WebUI.Services.CatalogServices.ProductServices;
using OllieShop.WebUI.Services.CommentServices;
using System.Net;

namespace OllieShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IProductService _productService;
        public ProductListController(ICommentService commentService, IProductService productService)
        {
            _productService = productService;
            _commentService = commentService;
        }

        public IActionResult Index(string id)
        {
            ViewBag.CategoryId = id;
            if (id.IsNullOrEmpty())
            {
                ViewBag.CategoryId = null;
            }
            return View();
        }

        public async Task<IActionResult> ProductDetail(string id)
        {
            var rateStatistics = await _commentService.GetRateStatisticsByProductId(id);
       
            ViewBag.RateCount = rateStatistics.TotalComments;
            ViewBag.RateAverage = rateStatistics.AverageRate;
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto) 
        {
            createCommentDto.CreatedAt = DateTime.Now;
            var response = await _commentService.CreateCommentAsync(createCommentDto);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Redirect($"/ProductList/ProductDetail/{createCommentDto.ProductId}");
            }

            return Redirect($"/ProductList/ProductDetail/{createCommentDto.ProductId}");
        }

        [HttpGet]
        public async Task<IActionResult> GetColorsForSize(string sizeId, string productId)
        {
            var colors = await _productService.GetAvailableColorsForSize(sizeId, productId);
            return Json(colors);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductWithAllDetails(string id)
        {
            var values = await _productService.GetAllProductDetailsById(id);
            return Json(values);
        }
    }
}
