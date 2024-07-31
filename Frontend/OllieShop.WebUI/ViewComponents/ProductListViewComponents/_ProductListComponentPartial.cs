using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OllieShop.DtoLayer.CatalogDtos.Product;
using OllieShop.WebUI.Services.CatalogServices.ProductServices;
using OllieShop.WebUI.Services.CommentServices;

namespace OllieShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public _ProductListComponentPartial(IProductService productService, ICommentService commentService)
        {
            _productService = productService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productsWithRates = new List<ResultProductsWithRates>();

            IEnumerable<ResultProductsWithCategoryDto> products;

            if (id.IsNullOrEmpty())
            {
                products = await _productService.GetAllProductsWithCategoryAsync();
            }
            else
            {
                products = await _productService.ProductListByCategoryId(id);
            }

            if (products.Any())
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
