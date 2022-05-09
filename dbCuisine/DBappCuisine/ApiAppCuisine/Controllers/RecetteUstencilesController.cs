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
    public class RecetteUstencilesController : ControllerBase
    {
        private readonly DbAppContext _context;

        public RecetteUstencilesController(DbAppContext context)
        {
            _context = context;
        }

        // GET: api/RecetteUstenciles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecetteUstencile>>> GetRecetteUstenciles()
        {
            return await _context.RecetteUstenciles.ToListAsync();
        }

        // GET: api/RecetteUstenciles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecetteUstencile>> GetRecetteUstencile(int id)
        {
            var recetteUstencile = await _context.RecetteUstenciles.FindAsync(id);

            if (recetteUstencile == null)
            {
                return NotFound();
            }

            return recetteUstencile;
        }

        // PUT: api/RecetteUstenciles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecetteUstencile(int id, RecetteUstencile recetteUstencile)
        {
            if (id != recetteUstencile.IdRecette)
            {
                return BadRequest();
            }

            _context.Entry(recetteUstencile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetteUstencileExists(id))
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

        // POST: api/RecetteUstenciles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecetteUstencile>> PostRecetteUstencile(RecetteUstencile recetteUstencile)
        {
            _context.RecetteUstenciles.Add(recetteUstencile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecetteUstencileExists(recetteUstencile.IdRecette))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecetteUstencile", new { id = recetteUstencile.IdRecette }, recetteUstencile);
        }

        // DELETE: api/RecetteUstenciles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecetteUstencile(int id)
        {
            var recetteUstencile = await _context.RecetteUstenciles.FindAsync(id);
            if (recetteUstencile == null)
            {
                return NotFound();
            }

            _context.RecetteUstenciles.Remove(recetteUstencile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecetteUstencileExists(int id)
        {
            return _context.RecetteUstenciles.Any(e => e.IdRecette == id);
        }
    }
}
