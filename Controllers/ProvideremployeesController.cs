using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DIENAPPRESTAPI.Data;
using DIENAPPRESTAPI.Models;

namespace DIENAPPRESTAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProvideremployeesController : ControllerBase
    {
        private readonly DIENAPPRESTAPIContext _context;

        public ProvideremployeesController(DIENAPPRESTAPIContext context)
        {
            _context = context;
        }

        // GET: api/Provideremployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provideremployee>>> GetAllProvideremployees()
        {
          if (_context.Provideremployees == null)
          {
              return NotFound();
          }
            return await _context.Provideremployees.ToListAsync();
        }

        // GET: api/Provideremployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provideremployee>> GetProvideremployeeById(int id)
        {
          if (_context.Provideremployees == null)
          {
              return NotFound();
          }
            var provideremployee = await _context.Provideremployees.FindAsync(id);

            if (provideremployee == null)
            {
                return NotFound();
            }

            return provideremployee;
        }

        // PUT: api/Provideremployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvideremployeeById(int id, Provideremployee provideremployee)
        {
            if (id != provideremployee.Provideremployeeid)
            {
                return BadRequest();
            }

            _context.Entry(provideremployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvideremployeeExists(id))
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

        // POST: api/Provideremployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Provideremployee>> CreateProvideremployee(Provideremployee provideremployee)
        {
          if (_context.Provideremployees == null)
          {
              return Problem("Entity set 'DIENAPPRESTAPIContext.Provideremployees'  is null.");
          }
            _context.Provideremployees.Add(provideremployee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProvideremployeeExists(provideremployee.Provideremployeeid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProvideremployee", new { id = provideremployee.Provideremployeeid }, provideremployee);
        }

        // DELETE: api/Provideremployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvideremployeeById(int id)
        {
            if (_context.Provideremployees == null)
            {
                return NotFound();
            }
            var provideremployee = await _context.Provideremployees.FindAsync(id);
            if (provideremployee == null)
            {
                return NotFound();
            }

            _context.Provideremployees.Remove(provideremployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProvideremployeeExists(int id)
        {
            return (_context.Provideremployees?.Any(e => e.Provideremployeeid == id)).GetValueOrDefault();
        }
    }
}
