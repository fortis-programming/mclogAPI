#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mclog_API.Data;
using mclog_API.Models;
using Microsoft.Data.SqlClient;

namespace mclog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserLogsController : ControllerBase
    {
        private readonly DataContext _context;

        public GetUserLogsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GetUserLogs
        [HttpGet]
        public List<GetUserLogs> GetgetUserLogs()
        {  
            return _context.getUserLogs.FromSqlRaw(@"SELECT ActivityLogs.Id, Users.Gender, Symptoms.SymptomName, ActivityLogs.Status, ActivityLogs.ActivityDate, Buildings.BuildingName, Buildings.Address FROM ActivityLogs 
            INNER JOIN BuildingLogs ON BuildingLogs.ActivityLogId = ActivityLogs.Id 
            INNER JOIN Buildings ON BuildingLogs.BuildingId = Buildings.id 
            INNER JOIN Users ON Users.Id = ActivityLogs.UserId 
            INNER JOIN UserHealthStatus ON UserHealthStatus.UserId = Users.Id 
            INNER JOIN Symptoms ON UserHealthStatus.Id = Symptoms.UserHealthStatusId").ToList();
        }   

        /*
        // GET: api/GetUserLogs/5
        [HttpGet("{id}")]
        public List<GetUserLogs> GetGetUserLogs(int id)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@ActivityId";
            param.DbType = System.Data.DbType.Int32;
            param.Value = id;
            return _context.getUserLogs.FromSqlRaw("EXEC sp_GetUserStatus @ActivityId", param).ToList();
            
            //return await _context.activityLogs.FromSqlRaw("EXEC sp_GetUserStatus @ActivityId", UserId).ToListAsync();
        }

        // PUT: api/GetUserLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGetUserLogs(int id, GetUserLogs getUserLogs)
        {
            if (id != getUserLogs.Id)
            {
                return BadRequest();
            }

            _context.Entry(getUserLogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetUserLogsExists(id))
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

        // POST: api/GetUserLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetUserLogs>> PostGetUserLogs(GetUserLogs getUserLogs)
        {
            _context.getUserLogs.Add(getUserLogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGetUserLogs", new { id = getUserLogs.Id }, getUserLogs);
        }

        // DELETE: api/GetUserLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGetUserLogs(int id)
        {
            var getUserLogs = await _context.getUserLogs.FindAsync(id);
            if (getUserLogs == null)
            {
                return NotFound();
            }

            _context.getUserLogs.Remove(getUserLogs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GetUserLogsExists(int id)
        {
            return _context.getUserLogs.Any(e => e.Id == id);
        }
        */
    }
}
