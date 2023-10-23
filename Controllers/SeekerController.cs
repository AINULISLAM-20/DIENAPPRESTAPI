using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DIENAPPRESTAPI.Controllers

{
    [Route("dienapp /[controller] /[action]")]
    [ApiController]
    public class SeekerController : ControllerBase
    {
        private readonly Contexts.SeekerContext _context;

        public SeekerController(Contexts.SeekerContext context)
        {
            _context = context;
        }

        // GET: api/SeekerItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.SeekerModel>>> GetAllSeeker()
        {
            if (_context.SeekerItem == null)
            {
                return NotFound();
            }
            return await _context.SeekerItem.ToListAsync();
        }

        // GET: api/SeekerItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.SeekerModel>> GetSeekerById(long id)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeeker(long id, Models.SeekerModel seekerItem)
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
        [HttpPost]
        public async Task<ActionResult<Models.SeekerModel>> CreateProvider(Models.SeekerModel seekerItem)
        {
            _context.SeekerItem.Add(seekerItem);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetAllSeeker), new { id = seekerItem.Id }, seekerItem);
        }

        // DELETE: api/SeekerItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeeker(long id)
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
