#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mclog_API.Data;
using mclog_API.Models;

namespace mclog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHealthStatusController : ControllerBase
    {
        private readonly DataContext _context;

        public UserHealthStatusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UserHealthStatus
        public async Task<ActionResult<IEnumerable<UserHealthStatusModel>>> GetSymptomsModel()
        {
            return await _context.userHealthStatus.ToListAsync();
        }

        [HttpGet("GetId/{id}")]
        public async Task<ActionResult<string>> GetuserHealthStatus(int id)
        {
            var allData = await _context.userHealthStatus.ToListAsync();
            var filteredLogs = new List<UserHealthStatusModel>();

            if (!HasRecord(id))
            {
                return NotFound();
            }

            allData.ForEach(d =>
            {
                if (d.UserId == id)
                {
                    filteredLogs.Add(d);
                }
            });
            return "{\"response\":\"" + filteredLogs[0].Id.ToString() + "\"}";
        }
        
        // GET: api/UserHealthStatus/5
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Object>> GetUserHealthStatus(int id)
        {
            var allData = await _context.userHealthStatus.ToListAsync();
            var filteredLogs = new List<UserHealthStatusModel>();

            if (!HasRecord(id))
            {
                return NotFound();
            }

            allData.ForEach(d =>
            {
                if (d.UserId == id)
                {
                    filteredLogs.Add(d);
                }
            });
            var objectResponse = new
            {
                id = filteredLogs[0].Id,
                temperature = filteredLogs[0].Temperature
            };
            return objectResponse;
        }
        
        [HttpGet("check/{id}")]
        public ActionResult<string> CheckIfUserExist(int id)
        {
            string message;
            
            if (HasRecord(id))
            {
                message = "{\"response\":\"" + "Exists" + "\"}";
            }
            else
            {
                message = "{\"response\":\"" + "None" + "\"}";
            }

            return message;
        }

        // PUT: api/UserHealthStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserHealthStatus(int id, UserHealthStatusModel userHealthStatus)
        {
            if (id != userHealthStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(userHealthStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserHealthStatusExists(id))
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

        // POST: api/UserHealthStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserHealthStatusModel>> PostUserHealthStatus(UserHealthStatusModel userHealthStatus)
        {
            _context.userHealthStatus.Add(userHealthStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserHealthStatus", new { id = userHealthStatus.Id }, userHealthStatus);
        }

        // DELETE: api/UserHealthStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserHealthStatus(int id)
        {
            var userHealthStatus = await _context.userHealthStatus.FindAsync(id);
            if (userHealthStatus == null)
            {
                return NotFound();
            }

            _context.userHealthStatus.Remove(userHealthStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserHealthStatusExists(int id)
        {
            return _context.userHealthStatus.Any(e => e.Id == id);
        }

        private bool HasRecord(int id)
        {
            return _context.userHealthStatus.Any(e => e.UserId == id);
        }
    }
}
