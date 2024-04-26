using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTrade.Models;

namespace WebApiTrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DProductTypesController : ControllerBase
    {
        private readonly Trade_dbContext _context;

        public DProductTypesController(Trade_dbContext context)
        {
            _context = context;
        }

        // GET: api/DProductTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DProductType>>> GetDProductTypes()
        {
          if (_context.DProductTypes == null)
          {
              return NotFound();
          }
            return await _context.DProductTypes.ToListAsync();
        }

        // GET: api/DProductTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DProductType>> GetDProductType(int id)
        {
          if (_context.DProductTypes == null)
          {
              return NotFound();
          }
            var dProductType = await _context.DProductTypes.FindAsync(id);

            if (dProductType == null)
            {
                return NotFound();
            }

            return dProductType;
        }

        // PUT: api/DProductTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDProductType(int id, DProductType dProductType)
        {
            if (id != dProductType.Id)
            {
                return BadRequest();
            }

            _context.Entry(dProductType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DProductTypeExists(id))
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

        // POST: api/DProductTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DProductType>> PostDProductType(DProductType dProductType)
        {
          if (_context.DProductTypes == null)
          {
              return Problem("Entity set 'Trade_dbContext.DProductTypes'  is null.");
          }
            _context.DProductTypes.Add(dProductType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDProductType", new { id = dProductType.Id }, dProductType);
        }

        // DELETE: api/DProductTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDProductType(int id)
        {
            if (_context.DProductTypes == null)
            {
                return NotFound();
            }
            var dProductType = await _context.DProductTypes.FindAsync(id);
            if (dProductType == null)
            {
                return NotFound();
            }

            _context.DProductTypes.Remove(dProductType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DProductTypeExists(int id)
        {
            return (_context.DProductTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
