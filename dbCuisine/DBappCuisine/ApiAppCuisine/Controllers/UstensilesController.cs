#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAppCuisine.entities;

namespace ApiAppCuisine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UstensilesController : ControllerBase
    {
        private readonly DbAppContext _context;

        public UstensilesController(DbAppContext context)
        {
            _context = context;
        }

        // GET: api/Ustensiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ustensile>>> GetUstensiles()
        {
            return await _context.Ustensiles.ToListAsync();
        }

        // GET: api/Ustensiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ustensile>> GetUstensile(int id)
        {
            var ustensile = await _context.Ustensiles.FindAsync(id);

            if (ustensile == null)
            {
                return NotFound();
            }

            return ustensile;
        }

        // PUT: api/Ustensiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUstensile(int id, Ustensile ustensile)
        {
            if (id != ustensile.IdUstensiles)
            {
                return BadRequest();
            }

            _context.Entry(ustensile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UstensileExists(id))
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

        // POST: api/Ustensiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ustensile>> PostUstensile(Ustensile ustensile)
        {
            _context.Ustensiles.Add(ustensile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUstensile", new { id = ustensile.IdUstensiles }, ustensile);
        }

        // DELETE: api/Ustensiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUstensile(int id)
        {
            var ustensile = await _context.Ustensiles.FindAsync(id);
            if (ustensile == null)
            {
                return NotFound();
            }

            _context.Ustensiles.Remove(ustensile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UstensileExists(int id)
        {
            return _context.Ustensiles.Any(e => e.IdUstensiles == id);
        }
    }
}
