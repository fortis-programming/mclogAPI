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
    public class BuildingsController : ControllerBase
    {
        private readonly DataContext _context;

        public BuildingsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingsModel>>> GetBuildings()
        {
            return await _context.buildings.ToListAsync();
        }

        // GET: api/Buildings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingsModel>> GetBuildingsModel(int id)
        {
            var buildingsModel = await _context.buildings.FindAsync(id);

            if (buildingsModel == null)
            {
                return NotFound();
            }

            return buildingsModel;
        }

        // PUT: api/Buildings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingsModel(int id, BuildingsModel buildingsModel)
        {
            if (id != buildingsModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(buildingsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingsModelExists(id))
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

        // POST: api/Buildings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuildingsModel>> PostBuildingsModel(BuildingsModel buildingsModel)
        {
            _context.buildings.Add(buildingsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuildingsModel", new { id = buildingsModel.Id }, buildingsModel);
        }

        // DELETE: api/Buildings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingsModel(int id)
        {
            var buildingsModel = await _context.buildings.FindAsync(id);
            if (buildingsModel == null)
            {
                return NotFound();
            }

            _context.buildings.Remove(buildingsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingsModelExists(int id)
        {
            return _context.buildings.Any(e => e.Id == id);
        }
    }
}
