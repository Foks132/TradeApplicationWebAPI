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
    public class DProductImagesController : ControllerBase
    {
        private readonly Trade_dbContext _context;

        public DProductImagesController(Trade_dbContext context)
        {
            _context = context;
        }

        // GET: api/DProductImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DProductImage>>> GetDProductImages()
        {
          if (_context.DProductImages == null)
          {
              return NotFound();
          }
            return await _context.DProductImages.ToListAsync();
        }

        // GET: api/DProductImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DProductImage>> GetDProductImage(int id)
        {
          if (_context.DProductImages == null)
          {
              return NotFound();
          }
            var dProductImage = await _context.DProductImages.FindAsync(id);

            if (dProductImage == null)
            {
                return NotFound();
            }

            return dProductImage;
        }

        // PUT: api/DProductImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDProductImage(int id, DProductImage dProductImage)
        {
            if (id != dProductImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(dProductImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DProductImageExists(id))
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

        // POST: api/DProductImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DProductImage>> PostDProductImage(DProductImage dProductImage)
        {
          if (_context.DProductImages == null)
          {
              return Problem("Entity set 'Trade_dbContext.DProductImages'  is null.");
          }
            _context.DProductImages.Add(dProductImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDProductImage", new { id = dProductImage.Id }, dProductImage);
        }

        // DELETE: api/DProductImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDProductImage(int id)
        {
            if (_context.DProductImages == null)
            {
                return NotFound();
            }
            var dProductImage = await _context.DProductImages.FindAsync(id);
            if (dProductImage == null)
            {
                return NotFound();
            }

            _context.DProductImages.Remove(dProductImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DProductImageExists(int id)
        {
            return (_context.DProductImages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
