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
    public class RequestotpsController : ControllerBase
    {
        private readonly DIENAPPRESTAPIContext _context;

        public RequestotpsController(DIENAPPRESTAPIContext context)
        {
            _context = context;
        }

        // GET: api/Requestotps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requestotp>>> GetAllRequestotps()
        {
          if (_context.Requestotps == null)
          {
              return NotFound();
          }
            return await _context.Requestotps.ToListAsync();
        }

        // GET: api/Requestotps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requestotp>> GetRequestotpById(int id)
        {
          if (_context.Requestotps == null)
          {
              return NotFound();
          }
            var requestotp = await _context.Requestotps.FindAsync(id);

            if (requestotp == null)
            {
                return NotFound();
            }

            return requestotp;
        }

        // PUT: api/Requestotps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequestotpById(int id, Requestotp requestotp)
        {
            if (id != requestotp.Otpid)
            {
                return BadRequest();
            }

            _context.Entry(requestotp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestotpExists(id))
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

        // POST: api/Requestotps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Requestotp>> CreateRequestotp(Requestotp requestotp)
        {
          if (_context.Requestotps == null)
          {
              return Problem("Entity set 'DIENAPPRESTAPIContext.Requestotps'  is null.");
          }
            _context.Requestotps.Add(requestotp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestotp", new { id = requestotp.Otpid }, requestotp);
        }

        // DELETE: api/Requestotps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestotpById(int id)
        {
            if (_context.Requestotps == null)
            {
                return NotFound();
            }
            var requestotp = await _context.Requestotps.FindAsync(id);
            if (requestotp == null)
            {
                return NotFound();
            }

            _context.Requestotps.Remove(requestotp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestotpExists(int id)
        {
            return (_context.Requestotps?.Any(e => e.Otpid == id)).GetValueOrDefault();
        }
    }
}
