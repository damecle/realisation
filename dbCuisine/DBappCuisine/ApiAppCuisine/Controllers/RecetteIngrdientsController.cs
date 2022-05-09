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
    public class RecetteIngrdientsController : ControllerBase
    {
        private readonly DbAppContext _context;

        public RecetteIngrdientsController(DbAppContext context)
        {
            _context = context;
        }

        // GET: api/RecetteIngrdients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecetteIngrdient>>> GetRecetteIngrdients()
        {
            return await _context.RecetteIngrdients.ToListAsync();
        }

        // GET: api/RecetteIngrdients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecetteIngrdient>> GetRecetteIngrdient(int id)
        {
            var recetteIngrdient = await _context.RecetteIngrdients.FindAsync(id);

            if (recetteIngrdient == null)
            {
                return NotFound();
            }

            return recetteIngrdient;
        }

        // PUT: api/RecetteIngrdients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecetteIngrdient(int id, RecetteIngrdient recetteIngrdient)
        {
            if (id != recetteIngrdient.IdRecette)
            {
                return BadRequest();
            }

            _context.Entry(recetteIngrdient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetteIngrdientExists(id))
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

        // POST: api/RecetteIngrdients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecetteIngrdient>> PostRecetteIngrdient(RecetteIngrdient recetteIngrdient)
        {
            _context.RecetteIngrdients.Add(recetteIngrdient);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecetteIngrdientExists(recetteIngrdient.IdRecette))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecetteIngrdient", new { id = recetteIngrdient.IdRecette }, recetteIngrdient);
        }

        // DELETE: api/RecetteIngrdients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecetteIngrdient(int id)
        {
            var recetteIngrdient = await _context.RecetteIngrdients.FindAsync(id);
            if (recetteIngrdient == null)
            {
                return NotFound();
            }

            _context.RecetteIngrdients.Remove(recetteIngrdient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecetteIngrdientExists(int id)
        {
            return _context.RecetteIngrdients.Any(e => e.IdRecette == id);
        }
    }
}
