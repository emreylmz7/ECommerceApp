using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Product;
using OllieShop.WebUI.Services.CatalogServices.ProductServices;
using OllieShop.WebUI.Services.CommentServices;

namespace OllieShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _AlsoLikeProductsComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;
        public _AlsoLikeProductsComponentPartial(IProductService productService, ICommentService commentService)
        {
            _productService = productService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = (await _productService.GetAllProductAsync()).Take(6).ToList();
            var productsWithRates = new List<ResultProductsWithRates>();

            if (products.Any() && products != null)
            {
                foreach (var product in products)
                {
                    var rateStatistics = await _commentService.GetRateStatisticsByProductId(product.ProductId!);
                    var productWithRates = new ResultProductsWithRates
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                        Price = product.Price,
                        CategoryId = product.CategoryId,
                        Description = product.Description,
                        ImageUrl = product.ImageUrl,
                        AverageRate = rateStatistics.AverageRate,
                        TotalComments = rateStatistics.TotalComments,
                    };

                    productsWithRates.Add(productWithRates);
                }

            }
            return View(productsWithRates);
        }
    }
}


