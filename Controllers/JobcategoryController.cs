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
    [Route("api/[controller]")]
    [ApiController]
    public class JobcategoryController : ControllerBase
    {
        private readonly DIENAPPRESTAPIContext _context;

        public JobcategoryController(DIENAPPRESTAPIContext context)
        {
            _context = context;
        }

        // GET: api/Jobcategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobcategory>>> GetJobcategories()
        {
          if (_context.Jobcategories == null)
          {
              return NotFound();
          }
            return await _context.Jobcategories.ToListAsync();
        }

        // GET: api/Jobcategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jobcategory>> GetJobcategory(int id)
        {
          if (_context.Jobcategories == null)
          {
              return NotFound();
          }
            var jobcategory = await _context.Jobcategories.FindAsync(id);

            if (jobcategory == null)
            {
                return NotFound();
            }

            return jobcategory;
        }

        // PUT: api/Jobcategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobcategory(int id, Jobcategory jobcategory)
        {
            if (id != jobcategory.Jobcategoryid)
            {
                return BadRequest();
            }

            _context.Entry(jobcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobcategoryExists(id))
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

        // POST: api/Jobcategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jobcategory>> PostJobcategory(Jobcategory jobcategory)
        {
          if (_context.Jobcategories == null)
          {
              return Problem("Entity set 'DIENAPPRESTAPIContext.Jobcategories'  is null.");
          }
            _context.Jobcategories.Add(jobcategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobcategoryExists(jobcategory.Jobcategoryid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobcategory", new { id = jobcategory.Jobcategoryid }, jobcategory);
        }

        // DELETE: api/Jobcategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobcategory(int id)
        {
            if (_context.Jobcategories == null)
            {
                return NotFound();
            }
            var jobcategory = await _context.Jobcategories.FindAsync(id);
            if (jobcategory == null)
            {
                return NotFound();
            }

            _context.Jobcategories.Remove(jobcategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobcategoryExists(int id)
        {
            return (_context.Jobcategories?.Any(e => e.Jobcategoryid == id)).GetValueOrDefault();
        }
    }
}
