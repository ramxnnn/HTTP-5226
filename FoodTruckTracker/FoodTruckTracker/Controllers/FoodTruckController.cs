using Microsoft.AspNetCore.Mvc;
using LocalFoodTruckTrackerSystem.Models;
using FoodTruckTracker.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using CoreEntityFramework.Interfaces;

namespace FoodTruckTracker.Controllers
{
    public class FoodTruckController : Controller
    {
        private readonly IFoodTruckService _foodTruckService;
        private readonly ILocationService _locationService; // Service for retrieving locations

        public FoodTruckController(IFoodTruckService foodTruckService, ILocationService locationService)
        {
            _foodTruckService = foodTruckService;
            _locationService = locationService; // Initialize location service
        }

        // GET: FoodTruck
        public async Task<IActionResult> Index()
        {
            var foodTrucks = await _foodTruckService.GetFoodTrucks();
            var locations = await _locationService.GetLocations();

            var viewModel = foodTrucks.Select(ft => new FoodTruckDto
            {
                FoodTruckId = ft.FoodTruckId,
                Name = ft.Name,
                Description = ft.Description,
                Contact = ft.Contact,
                LocationId = ft.LocationId,
                LocationAddress = locations.FirstOrDefault(loc => loc.LocationId == ft.LocationId)?.Address
            }).ToList();

            return View(viewModel);
        }

        // GET: FoodTruck/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var foodTruck = await _foodTruckService.GetFoodTruckById(id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            // Fetch and assign the location details
            var location = await _locationService.GetLocationById(foodTruck.LocationId);
            foodTruck.Location = location; // Manually assign the location

            return View(foodTruck);
        }


        // GET: FoodTruck/Create
        public async Task<IActionResult> Create()
        {
            var locations = await _locationService.GetLocations();
            ViewBag.LocationId = new SelectList(locations, "LocationId", "Address");
            return View();
        }

        // POST: FoodTruck/Create
        [HttpPost]
        public async Task<IActionResult> Create(FoodTruck foodTruck)
        {
            if (ModelState.IsValid)
            {
                await _foodTruckService.AddFoodTruck(foodTruck);
                return RedirectToAction(nameof(Index));
            }
            var locations = await _locationService.GetLocations();
            ViewBag.LocationId = new SelectList(locations, "LocationId", "Address", foodTruck.LocationId);
            return View(foodTruck);
        }

        // GET: FoodTruck/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var foodTruck = await _foodTruckService.GetFoodTruckById(id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            var locations = await _locationService.GetLocations();
            ViewBag.LocationId = new SelectList(locations, "LocationId", "Address", foodTruck.LocationId); // Ensure the selected location is set
            var foodTruckDto = new FoodTruckDto // Create and pass a FoodTruckDto to the view
            {
                FoodTruckId = foodTruck.FoodTruckId,
                Name = foodTruck.Name,
                Description = foodTruck.Description,
                Contact = foodTruck.Contact,
                LocationId = foodTruck.LocationId
            };

            return View(foodTruckDto); // Return the DTO directly
        }

        // POST: FoodTruck/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, FoodTruckDto foodTruckDto)
        {
            if (id != foodTruckDto.FoodTruckId)
            {
                return BadRequest(); // Ensure the ID in the URL matches the food truck being edited
            }

            if (ModelState.IsValid)
            {
                var foodTruck = new FoodTruck
                {
                    FoodTruckId = foodTruckDto.FoodTruckId,
                    Name = foodTruckDto.Name,
                    Description = foodTruckDto.Description,
                    Contact = foodTruckDto.Contact,
                    LocationId = foodTruckDto.LocationId
                };

                var success = await _foodTruckService.UpdateFoodTruck(foodTruck);
                if (success)
                {
                    return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
                }
                return NotFound(); // Return a 404 if the food truck could not be updated
            }

            // If we reach here, it means there was an error, so we repopulate the locations dropdown
            var locations = await _locationService.GetLocations();
            ViewBag.LocationId = new SelectList(locations, "LocationId", "Address", foodTruckDto.LocationId);
            return View(foodTruckDto); // Return to the Edit view with the invalid model
        }

        // GET: FoodTruck/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var foodTruck = await _foodTruckService.GetFoodTruckById(id);
            if (foodTruck == null)
            {
                return NotFound();
            }
            var location = await _locationService.GetLocationById(foodTruck.LocationId);
            foodTruck.Location = location;
            return View(foodTruck);
        }

        // POST: FoodTruck/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _foodTruckService.DeleteFoodTruck(id);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
