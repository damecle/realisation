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
    public class EtapeRecettesController : ControllerBase
    {
        private readonly DbAppContext _context;

        public EtapeRecettesController(DbAppContext context)
        {
            _context = context;
        }

        // GET: api/EtapeRecettes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtapeRecette>>> GetEtapeRecettes()
        {
            return await _context.EtapeRecettes.ToListAsync();
        }

        // GET: api/EtapeRecettes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EtapeRecette>> GetEtapeRecette(int id)
        {
            var etapeRecette = await _context.EtapeRecettes.FindAsync(id);

            if (etapeRecette == null)
            {
                return NotFound();
            }

            return etapeRecette;
        }

        // PUT: api/EtapeRecettes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtapeRecette(int id, EtapeRecette etapeRecette)
        {
            if (id != etapeRecette.IdEtapeRecette)
            {
                return BadRequest();
            }

            _context.Entry(etapeRecette).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtapeRecetteExists(id))
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

        // POST: api/EtapeRecettes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EtapeRecette>> PostEtapeRecette(EtapeRecette etapeRecette)
        {
            _context.EtapeRecettes.Add(etapeRecette);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtapeRecette", new { id = etapeRecette.IdEtapeRecette }, etapeRecette);
        }

        // DELETE: api/EtapeRecettes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtapeRecette(int id)
        {
            var etapeRecette = await _context.EtapeRecettes.FindAsync(id);
            if (etapeRecette == null)
            {
                return NotFound();
            }

            _context.EtapeRecettes.Remove(etapeRecette);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtapeRecetteExists(int id)
        {
            return _context.EtapeRecettes.Any(e => e.IdEtapeRecette == id);
        }
    }
}
