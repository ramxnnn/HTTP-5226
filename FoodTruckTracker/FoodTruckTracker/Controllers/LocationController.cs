﻿using Microsoft.AspNetCore.Mvc;

namespace FoodTruckTracker.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
