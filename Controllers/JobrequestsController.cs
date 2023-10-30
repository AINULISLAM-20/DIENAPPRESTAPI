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
    public class JobrequestsController : ControllerBase
    {
        private readonly DIENAPPRESTAPIContext _context;

        public JobrequestsController(DIENAPPRESTAPIContext context)
        {
            _context = context;
        }

        // GET: api/Jobrequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobrequest>>> GetAllJobrequests()
        {
          if (_context.Jobrequests == null)
          {
              return NotFound();
          }
            return await _context.Jobrequests.ToListAsync();
        }

        // GET: api/Jobrequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jobrequest>> GetJobrequesById(int id)
        {
          if (_context.Jobrequests == null)
          {
              return NotFound();
          }
            var jobrequest = await _context.Jobrequests.FindAsync(id);

            if (jobrequest == null)
            {
                return NotFound();
            }

            return jobrequest;
        }

        // PUT: api/Jobrequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobrequestById(int id, Jobrequest jobrequest)
        {
            if (id != jobrequest.Jobrequestid)
            {
                return BadRequest();
            }

            _context.Entry(jobrequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobrequestExists(id))
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

        // POST: api/Jobrequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jobrequest>> CreateJobrequest(Jobrequest jobrequest)
        {
          if (_context.Jobrequests == null)
          {
              return Problem("Entity set 'DIENAPPRESTAPIContext.Jobrequests'  is null.");
          }
            _context.Jobrequests.Add(jobrequest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobrequestExists(jobrequest.Jobrequestid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobrequest", new { id = jobrequest.Jobrequestid }, jobrequest);
        }

        // DELETE: api/Jobrequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobrequestById(int id)
        {
            if (_context.Jobrequests == null)
            {
                return NotFound();
            }
            var jobrequest = await _context.Jobrequests.FindAsync(id);
            if (jobrequest == null)
            {
                return NotFound();
            }

            _context.Jobrequests.Remove(jobrequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobrequestExists(int id)
        {
            return (_context.Jobrequests?.Any(e => e.Jobrequestid == id)).GetValueOrDefault();
        }
    }
}
