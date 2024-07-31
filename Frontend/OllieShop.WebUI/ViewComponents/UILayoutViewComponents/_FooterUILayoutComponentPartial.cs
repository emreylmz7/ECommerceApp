using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CatalogServices.AboutServices;

namespace OllieShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;
        public _FooterUILayoutComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts = (await _aboutService.GetAllAboutAsync()).Take(1).ToList();
            return View(abouts);
        }
    }
}
