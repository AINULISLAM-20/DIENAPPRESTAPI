using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DIENAPPRESTAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class SeekerController : ControllerBase
    {
        private readonly Contexts.SeekerContext _context;

        public SeekerController(Contexts.SeekerContext context)
        {
            _context = context;
        }

        // GET: api/SeekerItems
        [HttpGet("/dienapp/seeker/getallseeker")]
        public async Task<ActionResult<IEnumerable<Models.SeekerModel>>> GetSeekerItem()
        {
            if (_context.SeekerItem == null)
            {
                return NotFound();
            }
            return await _context.SeekerItem.ToListAsync();
        }

        // GET: api/SeekerItems/5
        [HttpGet("/dienapp/seeker/getseeker/{id}")]
        public async Task<ActionResult<Models.SeekerModel>> GetSeekerItem(long id)
        {
            if (_context.SeekerItem == null)
            {
                return NotFound();
            }
            var seekerItem = await _context.SeekerItem.FindAsync(id);

            if (seekerItem == null)
            {
                return NotFound();
            }

            return seekerItem;
        }

        // PUT: api/SeekerItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/dienapp/seeker/updateseeker/{id}")]
        public async Task<IActionResult> SeekerItem(long id, Models.SeekerModel seekerItem)
        {
            if (id != seekerItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(seekerItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeekerItemExists(id))
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

        // POST: api/SeekerItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/dienapp/seeker/createseeker")]
        public async Task<ActionResult<Models.SeekerModel>> PostSeekerItem(Models.SeekerModel seekerItem)
        {
            _context.SeekerItem.Add(seekerItem);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetSeekerItem), new { id = seekerItem.Id }, seekerItem);
        }

        // DELETE: api/SeekerItems/5
        [HttpDelete("/dienapp/seeker/deleteseeker/{id}")]
        public async Task<IActionResult> DeleteSeekerItem(long id)
        {
            if (_context.SeekerItem == null)
            {
                return NotFound();
            }
            var seekerItem = await _context.SeekerItem.FindAsync(id);
            if (seekerItem == null)
            {
                return NotFound();
            }

            _context.SeekerItem.Remove(seekerItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeekerItemExists(long id)
        {
            return (_context.SeekerItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
