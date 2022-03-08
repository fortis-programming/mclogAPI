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
    public class BuildingLogsController : ControllerBase
    {
        private readonly DataContext _context;

        public BuildingLogsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BuildingLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingLogsModel>>> GetBuildingLogsModel()
        {
            return await _context.buildingLogs.ToListAsync();
        }

        // GET: api/BuildingLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingLogsModel>> GetBuildingLogsModel(int id)
        {
            var buildingLogsModel = await _context.buildingLogs.FindAsync(id);

            if (buildingLogsModel == null)
            {
                return NotFound();
            }

            return buildingLogsModel;
        }

        // PUT: api/BuildingLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingLogsModel(int id, BuildingLogsModel buildingLogsModel)
        {
            if (id != buildingLogsModel.id)
            {
                return BadRequest();
            }

            _context.Entry(buildingLogsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingLogsModelExists(id))
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

        // POST: api/BuildingLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuildingLogsModel>> PostBuildingLogsModel(BuildingLogsModel buildingLogsModel)
        {
            _context.buildingLogs.Add(buildingLogsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuildingLogsModel", new { id = buildingLogsModel.id }, buildingLogsModel);
        }

        // DELETE: api/BuildingLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingLogsModel(int id)
        {
            var buildingLogsModel = await _context.buildingLogs.FindAsync(id);
            if (buildingLogsModel == null)
            {
                return NotFound();
            }

            _context.buildingLogs.Remove(buildingLogsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingLogsModelExists(int id)
        {
            return _context.buildingLogs.Any(e => e.id == id);
        }
    }
}
