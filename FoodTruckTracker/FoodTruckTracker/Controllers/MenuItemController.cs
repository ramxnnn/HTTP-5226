using Microsoft.AspNetCore.Mvc;
using LocalFoodTruckTrackerSystem.Models;
using FoodTruckTracker.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering; // Add this for SelectListItem

namespace FoodTruckTracker.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemsService _menuItemsService;

        public MenuItemController(IMenuItemsService menuItemsService)
        {
            _menuItemsService = menuItemsService; // Initialize menu item service
        }

        // GET: MenuItem
        public async Task<IActionResult> Index()
        {
            var menuItems = await _menuItemsService.GetMenuItems();
            return View(menuItems); // Pass the list of menu items to the view
        }

        // GET: MenuItem/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var menuItem = await _menuItemsService.GetMenuItemById(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem); // Return the menu item for details view
        }

        // GET: MenuItem/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.FoodTruckIdList = await _menuItemsService.GetFoodTruckSelectList(); // Populate dropdown
            return View(); // Return the create view
        }

        // POST: MenuItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuItem menuItem)
        {
            Console.WriteLine($"Name: {menuItem.Name}, Description: {menuItem.Description}, Price: {menuItem.Price}, FoodTruckId: {menuItem.FoodTruckId}");

            if (ModelState.IsValid)
            {
                await _menuItemsService.AddMenuItem(menuItem);
                return RedirectToAction(nameof(Index)); // Redirect to index after successful creation
            }

            // Log validation errors
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage); // Replace with your logging framework
            }

            ViewBag.FoodTruckIdList = await _menuItemsService.GetFoodTruckSelectList(); // Populate dropdown again
            return View(menuItem); // Return to the create view with the invalid model
        }

        // GET: MenuItem/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var menuItem = await _menuItemsService.GetMenuItemById(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            ViewBag.FoodTruckIdList = await _menuItemsService.GetFoodTruckSelectList(); // Populate dropdown
            return View(menuItem); // Return the menu item for edit view
        }

        // POST: MenuItem/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MenuItem menuItem)
        {
            if (id != menuItem.MenuItemId)
            {
                return BadRequest(); // Ensure the ID in the URL matches the menu item being edited
            }

            if (ModelState.IsValid)
            {
                var success = await _menuItemsService.UpdateMenuItem(menuItem);
                if (success)
                {
                    return RedirectToAction(nameof(Index)); // Redirect to index after successful update
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Unable to update the menu item. Please try again."); // Add error message
                }
            }

            ViewBag.FoodTruckIdList = await _menuItemsService.GetFoodTruckSelectList(); // Populate dropdown again
            return View(menuItem); // Return to the edit view with the invalid model
        }

        // GET: MenuItem/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var menuItem = await _menuItemsService.GetMenuItemById(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem); // Return the menu item for delete confirmation
        }

        // POST: MenuItem/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _menuItemsService.DeleteMenuItem(id);
            if (success)
            {
                return RedirectToAction(nameof(Index)); // Redirect to index after successful deletion
            }
            return NotFound(); // Return 404 if deletion was not successful
        }
    }
}
