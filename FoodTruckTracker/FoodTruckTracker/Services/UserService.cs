﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalFoodTruckTrackerSystem.Models;
using FoodTruckTracker.Controllers.Interfaces; 
using FoodTruckTracker.Data;

namespace FoodTruckTracker.Services
{
    public class UserService : IUserServices
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
                    return new NotFoundResult(); 
                }
                throw; 
            }

            return new NoContentResult(); 
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

            return new NoContentResult(); 
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
