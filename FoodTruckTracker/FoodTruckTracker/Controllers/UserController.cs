using Microsoft.AspNetCore.Mvc;

namespace FoodTruckTracker.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
