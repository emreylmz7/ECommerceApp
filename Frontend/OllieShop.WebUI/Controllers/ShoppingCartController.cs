﻿using Microsoft.AspNetCore.Mvc;

namespace OllieShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}