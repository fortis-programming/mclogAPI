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
using Newtonsoft.Json;

namespace mclog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthenticationController(DataContext context)
        {
            _context = context;
        }

        // POST: api/Authentication
        [HttpPost]
        public ActionResult<string> GetauthenticationModel(AuthenticationModel authenticationModel)
        {
            string message = "{\"message\":\""+ CheckIfMobileNumberIsRegistered(authenticationModel) + "\"}";
            //  return JsonConvert.SerializeObject(CheckIfMobileNumberIsRegistered(authenticationModel));
            //return await _context.authenticationModel.ToListAsync();
            return message;
        }

        // GET: api/Authentication/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthenticationModel>> GetAuthenticationModel(int id)
        {
            var authenticationModel = await _context.authenticationModel.FindAsync(id);

            if (authenticationModel == null)
            {
                return NotFound();
            }

            return authenticationModel;
        }

        // PUT: api/Authentication/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthenticationModel(int id, AuthenticationModel authenticationModel)
        {
            if (id != authenticationModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(authenticationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthenticationModelExists(id))
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

        // POST: api/Authentication
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*
        [HttpPost]
        public async Task<ActionResult<AuthenticationModel>> PostAuthenticationModel(AuthenticationModel authenticationModel)
        {
            _context.authenticationModel.Add(authenticationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthenticationModel", new { id = authenticationModel.Id }, authenticationModel);
        }
        */

        // DELETE: api/Authentication/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthenticationModel(int id)
        {
            var authenticationModel = await _context.authenticationModel.FindAsync(id);
            if (authenticationModel == null)
            {
                return NotFound();
            }

            _context.authenticationModel.Remove(authenticationModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private string CheckIfMobileNumberIsRegistered(AuthenticationModel authenticationModel)
        {
            var id = GetUserId(authenticationModel).Result.ToString();
            if(id != null && id != "0") {
                return id;
            } else if(id.ToString() == "0")
            {
                return "Username or password incorrect";
            }
            else
            {
                return "Error";
            }
            
        }

        private async Task<int> GetUserId(AuthenticationModel authenticationModel)
        {
            var allData = await _context.Users.ToListAsync();
            int filteredLogs = 0;

            allData.ForEach(d =>
            {
                if (d.PhoneNumber.ToString() == authenticationModel.MobileNumber.ToString() && d.Password == authenticationModel.Password)
                {
                    filteredLogs = d.Id;
                }
            });
            return filteredLogs;
        }

        private bool AuthenticationModelExists(int id)
        {
            return _context.authenticationModel.Any(e => e.Id == id);
        }
    }
}
