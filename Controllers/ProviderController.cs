using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DIENAPPRESTAPI.Controllers
{
    [Route("dienapp/[controller]/[action]")]
    [ApiController]
    public class Provider : ControllerBase
    {
        private readonly Contexts.ProviderContext _context;

        public Provider(Contexts.ProviderContext context)
        {
            _context = context;
        }

        // GET: api/Provider
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ProviderModel>>> GetAllProvider()
        {

          if (_context.ProviderItem == null)
          {
              return NotFound();
          }
            return await _context.ProviderItem.ToListAsync();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.ProviderModel>> GetProviderById(long id)
        {
          if (_context.ProviderItem == null)
          {
              return NotFound();
          }
            var provider = await _context.ProviderItem.FindAsync(id);

            if (provider == null)
            {
                return NotFound();
            }

            return provider;
        }

        // PUT: api/Provider/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvider(long id, Models.ProviderModel provider)
        {
            if (id != provider.Id)
            {
                return BadRequest();
            }

            _context.Entry(provider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(id))
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

        // POST: api/Provider
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.ProviderModel>> CreateProvider(Models.ProviderModel provider)
        {
          if (_context.ProviderItem == null)
          {
              return Problem("Entity set 'Provider.ProviderItem'  is null.");
          }
            _context.ProviderItem.Add(provider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvider", new { id = provider.Id }, provider);
        }

        // DELETE: api/Provider/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider(long id)
        {
            if (_context.ProviderItem == null)
            {
                return NotFound();
            }
            var provider = await _context.ProviderItem.FindAsync(id);
            if (provider == null)
            {
                return NotFound();
            }

            _context.ProviderItem.Remove(provider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProviderExists(long id)
        {
            return (_context.ProviderItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
