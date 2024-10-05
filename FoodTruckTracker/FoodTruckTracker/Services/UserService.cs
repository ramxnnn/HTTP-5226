using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalFoodTruckTrackerSystem.Models;
using FoodTruckTracker.Controllers.Interfaces; // Import the existing interface
using FoodTruckTracker.Data;

namespace FoodTruckTracker.Services
{
    public class UserService : IUsersController // Implement the existing interface
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/{id}
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return new NotFoundResult(); // Return 404 if not found
            }

            return user; // Return the found user
        }

        // PUT: api/Users/{id}
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return new BadRequestResult(); // Return 400 for bad request
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return new NotFoundResult(); // Return 404 if item does not exist
                }
                throw; // Rethrow if there's another issue
            }

            return new NoContentResult(); // Return 204 No Content on success
        }

        // POST: api/Users
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetUser), "Users", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/{id}
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return new NotFoundResult(); // Return 404 if item not found
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return new NoContentResult(); // Return 204 No Content on success
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
