using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CargoService;

namespace OllieShop.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    [Route("User/UserCargo")]
    public class UserCargoController : Controller
    {
        private readonly ICargoService _cargoService;
        private readonly ICargoDetailService _cargoDetailService;
        public UserCargoController(ICargoService cargoService, ICargoDetailService cargoDetailService)
        {
            _cargoService = cargoService;
            _cargoDetailService = cargoDetailService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var cargoStatistics = await _cargoService.GetCargoStatistics();
            var cargos = (await _cargoService.GetAllCargoByUserAsync())
                            .OrderByDescending(o => o.DispatchDate)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

            var totalCargos = cargoStatistics.TotalCargoCount;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCargos / (double)pageSize);
            ViewBag.CurrentPage = pageNumber;

            return View(cargos);
        }

        [Route("CargoDetails/{id}")]
        [HttpGet]
        public async Task<IActionResult> CargoDetails(string id)
        {
            var cargo = await _cargoService.GetByIdCargoAsync(id);
            return View(cargo);
        }
    }
}
