using Microsoft.AspNetCore.Mvc;
using LocalFoodTruckTrackerSystem.Models;
using FoodTruckTracker.Services.Interfaces;
namespace FoodTruckTracker.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService; // Initialize location service
        }

        // GET: Location
        public async Task<IActionResult> Index()
        {
            var locations = await _locationService.GetLocations();
            return View(locations); // Pass the list of locations to the view
        }

        // GET: Location/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var location = await _locationService.GetLocationById(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location); // Return the location for details view
        }

        // GET: Location/Create
        public IActionResult Create()
        {
            return View(); // Return the create view
        }

        // POST: Location/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Location location)
        {
            if (ModelState.IsValid)
            {
                await _locationService.AddLocation(location);
                return RedirectToAction(nameof(Index)); 
            }
            return View(location); 
        }

        // GET: Location/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var location = await _locationService.GetLocationById(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location); // Return the location for edit view
        }

        // POST: Location/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Location location)
        {
            if (id != location.LocationId)
            {
                return BadRequest(); 
            }

            if (ModelState.IsValid)
            {
                var success = await _locationService.UpdateLocation(location);
                if (success)
                {
                    return RedirectToAction(nameof(Index)); 
                }
                return NotFound(); 
            }

            return View(location);
        }

        // GET: Location/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var location = await _locationService.GetLocationById(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location); 
        }

        // POST: Location/DeleteConfirmed/{id}
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int locationId)
        {
            var success = await _locationService.DeleteLocation(locationId);
            if (success)
            {
                return RedirectToAction(nameof(Index)); // Redirect to index after successful deletion
            }
            return NotFound(); // Return 404 if deletion was not successful
        }
    }
}
