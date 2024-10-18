using Microsoft.AspNetCore.Mvc;

namespace FoodTruckTracker.Controllers
{
    public class MenuItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
