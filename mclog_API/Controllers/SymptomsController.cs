#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mclog_API.Data;
using mclog_API.Models;

namespace mclog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymptomsController : ControllerBase
    {
        private readonly DataContext _context;

        public SymptomsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Symptoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SymptomsModel>>> GetSymptomsModel()
        {
            return await _context.symptoms.ToListAsync();
        }

        // GET: api/Symptoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SymptomsModel>>> GetSymptomsModel(int id)
        {
            var allData = await _context.symptoms.ToListAsync();
            var filteredLogs = new List<SymptomsModel>();

            if (!HasRecord(id))
            {
                return NotFound();
            }

            allData.ForEach(d =>
            {
                if (d.UserHealthStatusId == id)
                {
                    filteredLogs.Add(d);
                }
            });
            return filteredLogs;
        }

        [HttpGet("check/{id}")]
        public ActionResult<string> CheckIfUserHasSymptoms(int id)
        {
            string message;
            if (HasRecord(id))
            {
                message = "{\"response\":\"" + "Has symptoms" + "\"}";
            } else
            {
                message = "{\"response\":\"" + "Healthy" + "\"}";
            }
            
            return message;
        }

        // PUT: api/Symptoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSymptomsModel(int id, SymptomsModel symptomsModel)
        {
            if (id != symptomsModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(symptomsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SymptomsModelExists(id))
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

        // POST: api/Symptoms/1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<ActionResult<SymptomsModel>> PostSymptomsModel(SymptomsModel symptomsModel)
        {
            _context.symptoms.Add(symptomsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSymptomsModel", new { id = symptomsModel.Id }, symptomsModel);
        }

        // DELETE: api/Symptoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSymptomsModel(int id)
        {
            var symptomsModel = await _context.symptoms.FindAsync(id);
            if (symptomsModel == null)
            {
                return NotFound();
            }

            _context.symptoms.Remove(symptomsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SymptomsModelExists(int id)
        {
            return _context.symptoms.Any(e => e.Id == id);
        }

        private bool HasRecord(int id)
        {
            return _context.symptoms.Any(e => e.UserHealthStatusId == id);
        }
    }
}
