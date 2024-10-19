using Microsoft.AspNetCore.Mvc;
using LocalFoodTruckTrackerSystem.Models;
using FoodTruckTracker.Controllers.Interfaces;

namespace FoodTruckTracker.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var users = await _userServices.GetUser();
            return View(users.Value); 
        }

        // GET: User/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user.Value);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _userServices.PostUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user.Value);
        }

        // POST: User/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _userServices.PutUser(id, user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user.Value);
        }

        // POST: User/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userServices.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
