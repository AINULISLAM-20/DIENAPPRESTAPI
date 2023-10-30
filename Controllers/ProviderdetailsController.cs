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
    public class ProviderdetailsController : ControllerBase
    {
        private readonly DIENAPPRESTAPIContext _context;

        public ProviderdetailsController(DIENAPPRESTAPIContext context)
        {
            _context = context;
        }

        // GET: api/Providerdetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Providerdetail>>> GetAllProviderdetails()
        {
          if (_context.Providerdetails == null)
          {
              return NotFound();
          }
            return await _context.Providerdetails.ToListAsync();
        }

        // GET: api/Providerdetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Providerdetail>> GetProviderdetailById(int id)
        {
          if (_context.Providerdetails == null)
          {
              return NotFound();
          }
            var providerdetail = await _context.Providerdetails.FindAsync(id);

            if (providerdetail == null)
            {
                return NotFound();
            }

            return providerdetail;
        }

        // PUT: api/Providerdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProviderdetailById(int id, Providerdetail providerdetail)
        {
            if (id != providerdetail.Providerdetailsid)
            {
                return BadRequest();
            }

            _context.Entry(providerdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderdetailExists(id))
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

        // POST: api/Providerdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Providerdetail>> CreateProviderdetail(Providerdetail providerdetail)
        {
          if (_context.Providerdetails == null)
          {
              return Problem("Entity set 'DIENAPPRESTAPIContext.Providerdetails'  is null.");
          }
            _context.Providerdetails.Add(providerdetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProviderdetailExists(providerdetail.Providerdetailsid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProviderdetail", new { id = providerdetail.Providerdetailsid }, providerdetail);
        }

        // DELETE: api/Providerdetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProviderdetailById(int id)
        {
            if (_context.Providerdetails == null)
            {
                return NotFound();
            }
            var providerdetail = await _context.Providerdetails.FindAsync(id);
            if (providerdetail == null)
            {
                return NotFound();
            }

            _context.Providerdetails.Remove(providerdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProviderdetailExists(int id)
        {
            return (_context.Providerdetails?.Any(e => e.Providerdetailsid == id)).GetValueOrDefault();
        }
    }
}
