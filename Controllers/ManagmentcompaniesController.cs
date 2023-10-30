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
    public class ManagmentcompaniesController : ControllerBase
    {
        private readonly DIENAPPRESTAPIContext _context;

        public ManagmentcompaniesController(DIENAPPRESTAPIContext context)
        {
            _context = context;
        }

        // GET: api/Managmentcompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Managmentcompany>>> GetAllManagmentcompanies()
        {
          if (_context.Managmentcompanies == null)
          {
              return NotFound();
          }
            return await _context.Managmentcompanies.ToListAsync();
        }

        // GET: api/Managmentcompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Managmentcompany>> GetManagmentcompanyById(int id)
        {
          if (_context.Managmentcompanies == null)
          {
              return NotFound();
          }
            var managmentcompany = await _context.Managmentcompanies.FindAsync(id);

            if (managmentcompany == null)
            {
                return NotFound();
            }

            return managmentcompany;
        }

        // PUT: api/Managmentcompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManagmentcompanyById(int id, Managmentcompany managmentcompany)
        {
            if (id != managmentcompany.ManagmentId)
            {
                return BadRequest();
            }

            _context.Entry(managmentcompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagmentcompanyExists(id))
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

        // POST: api/Managmentcompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Managmentcompany>> CreateManagmentcompany(Managmentcompany managmentcompany)
        {
          if (_context.Managmentcompanies == null)
          {
              return Problem("Entity set 'DIENAPPRESTAPIContext.Managmentcompanies'  is null.");
          }
            _context.Managmentcompanies.Add(managmentcompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManagmentcompany", new { id = managmentcompany.ManagmentId }, managmentcompany);
        }

        // DELETE: api/Managmentcompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagmentcompanyById(int id)
        {
            if (_context.Managmentcompanies == null)
            {
                return NotFound();
            }
            var managmentcompany = await _context.Managmentcompanies.FindAsync(id);
            if (managmentcompany == null)
            {
                return NotFound();
            }

            _context.Managmentcompanies.Remove(managmentcompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagmentcompanyExists(int id)
        {
            return (_context.Managmentcompanies?.Any(e => e.ManagmentId == id)).GetValueOrDefault();
        }
    }
}
