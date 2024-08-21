using Microsoft.AspNetCore.Mvc;
using OllieShop.WebUI.Services.CargoService;

namespace OllieShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCargo")]
    public class AdminCargoController : Controller
    {
        private readonly ICargoService _cargoService;
        private readonly ICargoDetailService _cargoDetailService;

        public AdminCargoController(ICargoService cargoService, ICargoDetailService cargoDetailService)
        {
            _cargoService = cargoService;
            _cargoDetailService = cargoDetailService;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var cargoStatistics = await _cargoService.GetCargoStatistics();

            var cargos = (await _cargoService.GetAllCargoAsync())
                            .OrderByDescending(o => o.CargoId)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

            var totalCargos = cargoStatistics.TotalCargoCount;

            ViewBag.TotalPages = (int)Math.Ceiling(totalCargos / (double)pageSize);
            ViewBag.CurrentPage = pageNumber;

            ViewBag.One = "Total Cargos";
            ViewBag.OneDesc = cargoStatistics.TotalCargoCount;
            ViewBag.OneIcon = "bx bx-package bx-lg text-success p-3";

            ViewBag.Two = "Delivered Cargos";
            ViewBag.TwoDesc = cargoStatistics.DeliveredCargoCount;
            ViewBag.TwoIcon = "bx bx-check-circle bx-lg text-info p-3";

            ViewBag.Three = "Pending Delivery";
            ViewBag.ThreeDesc = cargoStatistics.PendingDeliveryCargoCount;
            ViewBag.ThreeIcon = "bx bx-time-five bx-lg text-warning p-3";

            ViewBag.Four = "Dispatched in Last 30 Days";
            ViewBag.FourDesc = cargoStatistics.CargosDispatchedInLast30Days;
            ViewBag.FourIcon = "bx bx-calendar bx-lg text-primary p-3";

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
