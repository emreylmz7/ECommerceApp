using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OllieShop.DtoLayer.CommentDtos;
using OllieShop.WebUI.Services.CommentServices;
using System.Net;

namespace OllieShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ICommentService _commentService;
        public ProductListController(ICommentService commentService)
        {
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
    }
}
