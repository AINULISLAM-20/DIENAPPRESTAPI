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
    public class SeekersController : ControllerBase
    {
        private readonly DIENAPPRESTAPIContext _context;

        public SeekersController(DIENAPPRESTAPIContext context)
        {
            _context = context;
        }

        // GET: api/Seekers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seeker>>> GetAllSeekers()
        {
          if (_context.Seekers == null)
          {
              return NotFound();
          }
            return await _context.Seekers.ToListAsync();
        }

        // GET: api/Seekers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seeker>> GetSeekerById(int id)
        {
          if (_context.Seekers == null)
          {
              return NotFound();
          }
            var seeker = await _context.Seekers.FindAsync(id);

            if (seeker == null)
            {
                return NotFound();
            }

            return seeker;
        }

        // PUT: api/Seekers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeekerById(int id, Seeker seeker)
        {
            if (id != seeker.Skeerid)
            {
                return BadRequest();
            }

            _context.Entry(seeker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeekerExists(id))
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

        // POST: api/Seekers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seeker>> createSeeker(Seeker seeker)
        {
          if (_context.Seekers == null)
          {
              return Problem("Entity set 'DIENAPPRESTAPIContext.Seekers'  is null.");
          }
            _context.Seekers.Add(seeker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeeker", new { id = seeker.Skeerid }, seeker);
        }

        // DELETE: api/Seekers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeekerById(int id)
        {
            if (_context.Seekers == null)
            {
                return NotFound();
            }
            var seeker = await _context.Seekers.FindAsync(id);
            if (seeker == null)
            {
                return NotFound();
            }

            _context.Seekers.Remove(seeker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeekerExists(int id)
        {
            return (_context.Seekers?.Any(e => e.Skeerid == id)).GetValueOrDefault();
        }
    }
}
