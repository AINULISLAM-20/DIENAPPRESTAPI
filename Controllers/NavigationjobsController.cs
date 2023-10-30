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
    public class NavigationjobsController : ControllerBase
    {
        private readonly DIENAPPRESTAPIContext _context;

        public NavigationjobsController(DIENAPPRESTAPIContext context)
        {
            _context = context;
        }

        // GET: api/Navigationjobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Navigationjob>>> GetAllNavigationjobs()
        {
          if (_context.Navigationjobs == null)
          {
              return NotFound();
          }
            return await _context.Navigationjobs.ToListAsync();
        }

        // GET: api/Navigationjobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Navigationjob>> GetNavigationjobById(int? id)
        {
          if (_context.Navigationjobs == null)
          {
              return NotFound();
          }
            var navigationjob = await _context.Navigationjobs.FindAsync(id);

            if (navigationjob == null)
            {
                return NotFound();
            }

            return navigationjob;
        }

        // PUT: api/Navigationjobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNavigationjobById(int? id, Navigationjob navigationjob)
        {
            if (id != navigationjob.NavigationjobId)
            {
                return BadRequest();
            }

            _context.Entry(navigationjob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NavigationjobExists(id))
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

        // POST: api/Navigationjobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Navigationjob>> CreateNavigationjob(Navigationjob navigationjob)
        {
          if (_context.Navigationjobs == null)
          {
              return Problem("Entity set 'DIENAPPRESTAPIContext.Navigationjobs'  is null.");
          }
            _context.Navigationjobs.Add(navigationjob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNavigationjob", new { id = navigationjob.NavigationjobId }, navigationjob);
        }

        // DELETE: api/Navigationjobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNavigationjobById(int? id)
        {
            if (_context.Navigationjobs == null)
            {
                return NotFound();
            }
            var navigationjob = await _context.Navigationjobs.FindAsync(id);
            if (navigationjob == null)
            {
                return NotFound();
            }

            _context.Navigationjobs.Remove(navigationjob);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NavigationjobExists(int? id)
        {
            return (_context.Navigationjobs?.Any(e => e.NavigationjobId == id)).GetValueOrDefault();
        }
    }
}
