using Microsoft.AspNetCore.Mvc;
using OllieShop.DtoLayer.CatalogDtos.Carousel;
using OllieShop.DtoLayer.CatalogDtos.Category;
using OllieShop.WebUI.Services.ApiServices;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial: ViewComponent
    {
        private readonly IApiService _apiService;
        public _CarouselDefaultComponentPartial(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carousels = await _apiService.GetAsync<List<ResultCarouselDto>>("https://localhost:7220/api/Carousels");
            return View(carousels);
        }
    }
}
