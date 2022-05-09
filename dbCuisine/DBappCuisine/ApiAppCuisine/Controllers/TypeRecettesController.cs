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
    public class TypeRecettesController : ControllerBase
    {
        private readonly DbAppContext _context;

        public TypeRecettesController(DbAppContext context)
        {
            _context = context;
        }

        // GET: api/TypeRecettes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeRecette>>> GetTypeRecettes()
        {
            return await _context.TypeRecettes.ToListAsync();
        }

        // GET: api/TypeRecettes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeRecette>> GetTypeRecette(int id)
        {
            var typeRecette = await _context.TypeRecettes.FindAsync(id);

            if (typeRecette == null)
            {
                return NotFound();
            }

            return typeRecette;
        }

        // PUT: api/TypeRecettes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeRecette(int id, TypeRecette typeRecette)
        {
            if (id != typeRecette.IdTypeRecette)
            {
                return BadRequest();
            }

            _context.Entry(typeRecette).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeRecetteExists(id))
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

        // POST: api/TypeRecettes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeRecette>> PostTypeRecette(TypeRecette typeRecette)
        {
            _context.TypeRecettes.Add(typeRecette);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeRecette", new { id = typeRecette.IdTypeRecette }, typeRecette);
        }

        // DELETE: api/TypeRecettes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeRecette(int id)
        {
            var typeRecette = await _context.TypeRecettes.FindAsync(id);
            if (typeRecette == null)
            {
                return NotFound();
            }

            _context.TypeRecettes.Remove(typeRecette);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeRecetteExists(int id)
        {
            return _context.TypeRecettes.Any(e => e.IdTypeRecette == id);
        }
    }
}
