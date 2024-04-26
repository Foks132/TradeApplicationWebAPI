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
    public class DProductsController : ControllerBase
    {
        private readonly Trade_dbContext _context;

        public DProductsController(Trade_dbContext context)
        {
            _context = context;
        }

        // GET: api/DProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DProduct>>> GetDProducts()
        {
          if (_context.DProducts == null)
          {
              return NotFound();
          }
            return await _context.DProducts.ToListAsync();
        }

        // GET: api/DProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DProduct>> GetDProduct(int id)
        {
          if (_context.DProducts == null)
          {
              return NotFound();
          }
            var dProduct = await _context.DProducts.FindAsync(id);

            if (dProduct == null)
            {
                return NotFound();
            }

            return dProduct;
        }

        // PUT: api/DProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDProduct(int id, DProduct dProduct)
        {
            if (id != dProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(dProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DProductExists(id))
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

        // POST: api/DProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DProduct>> PostDProduct(DProduct dProduct)
        {
          if (_context.DProducts == null)
          {
              return Problem("Entity set 'Trade_dbContext.DProducts'  is null.");
          }
            _context.DProducts.Add(dProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDProduct", new { id = dProduct.Id }, dProduct);
        }

        // DELETE: api/DProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDProduct(int id)
        {
            if (_context.DProducts == null)
            {
                return NotFound();
            }
            var dProduct = await _context.DProducts.FindAsync(id);
            if (dProduct == null)
            {
                return NotFound();
            }

            _context.DProducts.Remove(dProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DProductExists(int id)
        {
            return (_context.DProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
