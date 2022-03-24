#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mclog_API.Data;
using mclog_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace mclog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        //used in adminview
        [Route("GetAllUsers")]
        [HttpGet]
        public List<AdminModel> GetAllUsers()
        {
            /*
            object data = null;
            try
            {
                var users = await _context.users.Select(x => new UserModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate,
                    Province = x.Province,
                    City = x.City,
                    Baranggay = x.Baranggay,
                    Gender = x.Gender,
                    PhoneNumber = x.PhoneNumber,
                })
                .AsNoTracking()
                .ToListAsync();
                var healthStatus = await _context.userHealthStatus.AsNoTracking().ToListAsync();
                var symptoms = await _context.symptoms.AsNoTracking().ToListAsync();
                data = new { Users = users, HealthStatus = healthStatus, Symptoms = symptoms };
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            return data;
            */
            return _context.adminModels.FromSqlRaw("SELECT Users.FirstName, Users.MiddleName, Users.Province, Users.Region, Users.City, Users.Baranggay, Users.LastName, Users.Gender, Users.Birthdate, Users.PhoneNumber, UserHealthStatus.Id From Users INNER JOIN UserHealthStatus ON UserHealthStatus.UserId = Users.id").ToList();
        }

        // GET: api/Users
        /*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            return await _context.users.ToListAsync(); ; 
        }
        */
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser(UserModel user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckIfMobileIsRegistered(string MobileNumber)
        {
            return _context.users.Any(e => e.PhoneNumber == MobileNumber);
        }

        private bool UserExists(int id)
        {
            return _context.users.Any(e => e.Id == id);
        }
    }
}
