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
    public class JobpaymentsController : ControllerBase
    {
        private readonly DIENAPPRESTAPIContext _context;

        public JobpaymentsController(DIENAPPRESTAPIContext context)
        {
            _context = context;
        }

        // GET: api/Jobpayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobpayment>>> GetJobpayments()
        {
          if (_context.Jobpayments == null)
          {
              return NotFound();
          }
            return await _context.Jobpayments.ToListAsync();
        }

        // GET: api/Jobpayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jobpayment>> GetJobpayment(int? id)
        {
          if (_context.Jobpayments == null)
          {
              return NotFound();
          }
            var jobpayment = await _context.Jobpayments.FindAsync(id);

            if (jobpayment == null)
            {
                return NotFound();
            }

            return jobpayment;
        }

        // PUT: api/Jobpayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobpayment(int? id, Jobpayment jobpayment)
        {
            if (id != jobpayment.JobpaymentId)
            {
                return BadRequest();
            }

            _context.Entry(jobpayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobpaymentExists(id))
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

        // POST: api/Jobpayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jobpayment>> PostJobpayment(Jobpayment jobpayment)
        {
          if (_context.Jobpayments == null)
          {
              return Problem("Entity set 'DIENAPPRESTAPIContext.Jobpayments'  is null.");
          }
            _context.Jobpayments.Add(jobpayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobpayment", new { id = jobpayment.JobpaymentId }, jobpayment);
        }

        // DELETE: api/Jobpayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobpayment(int? id)
        {
            if (_context.Jobpayments == null)
            {
                return NotFound();
            }
            var jobpayment = await _context.Jobpayments.FindAsync(id);
            if (jobpayment == null)
            {
                return NotFound();
            }

            _context.Jobpayments.Remove(jobpayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobpaymentExists(int? id)
        {
            return (_context.Jobpayments?.Any(e => e.JobpaymentId == id)).GetValueOrDefault();
        }
    }
}
