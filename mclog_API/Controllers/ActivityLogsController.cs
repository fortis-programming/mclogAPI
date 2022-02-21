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

namespace mclog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogsController : ControllerBase
    {
        private readonly DataContext _context;

        public ActivityLogsController(DataContext context)
        {
            _context = context;
        }

        // WILL REMOVE THIS ONE AFTER DEVELOPMENT
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityLogs>>> GetUsers()
        {
            return await _context.activityLogs.ToListAsync(); ;
        }

        // GET: api/ActivityLogs/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ActivityLogs>>> GetLogs(string id)
        {
            var allData = await _context.activityLogs.ToListAsync();
            var filteredLogs = new List<ActivityLogs>();
            
            allData.ForEach(d =>
            {
                if (d.UserId == id)
                {
                    filteredLogs.Add(d);
                }
            });
            return filteredLogs;
        }

        // GET: api/ActivityLogs/5
        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityLogs>> GetActivityLogs(int id)
        {
            var activityLogs = await _context.activityLogs.FindAsync(id);

            if (activityLogs == null)
            {
                return NotFound();
            }

            return activityLogs;
        }*/

        // PUT: api/ActivityLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityLogs(int id, ActivityLogs activityLogs)
        {
            if (id != activityLogs.Id)
            {
                return BadRequest();
            }

            _context.Entry(activityLogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityLogsExists(id))
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

        // POST: api/ActivityLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<ActionResult<ActivityLogs>> PostActivityLogs(int id, ActivityLogs activityLogs)
        {
            _context.activityLogs.Add(activityLogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityLogs", new { id = activityLogs }, activityLogs);
        }

        // DELETE: api/ActivityLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityLogs(int id)
        {
            var activityLogs = await _context.activityLogs.FindAsync(id);
            if (activityLogs == null)
            {
                return NotFound();
            }

            _context.activityLogs.Remove(activityLogs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityLogsExists(int id)
        {
            return _context.activityLogs.Any(e => e.Id == id);
        }
    }
}
