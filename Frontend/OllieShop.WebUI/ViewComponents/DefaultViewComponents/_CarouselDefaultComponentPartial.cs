using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CatalogServices.CarouselServices;

namespace OllieShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial: ViewComponent
    {
        private readonly ICarouselService _carouselService;
        public _CarouselDefaultComponentPartial(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carousels = await _carouselService.GetAllCarouselAsync();
            return View(carousels);
        }
    }
}
