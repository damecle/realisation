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
    public class ImageRecettesController : ControllerBase
    {
        private readonly DbAppContext _context;

        public ImageRecettesController(DbAppContext context)
        {
            _context = context;
        }

        // GET: api/ImageRecettes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageRecette>>> GetImageRecettes()
        {
            return await _context.ImageRecettes.ToListAsync();
        }

        // GET: api/ImageRecettes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageRecette>> GetImageRecette(int id)
        {
            var imageRecette = await _context.ImageRecettes.FindAsync(id);

            if (imageRecette == null)
            {
                return NotFound();
            }

            return imageRecette;
        }

        // PUT: api/ImageRecettes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageRecette(int id, ImageRecette imageRecette)
        {
            if (id != imageRecette.IdPhoto)
            {
                return BadRequest();
            }

            _context.Entry(imageRecette).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageRecetteExists(id))
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

        // POST: api/ImageRecettes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageRecette>> PostImageRecette(ImageRecette imageRecette)
        {
            _context.ImageRecettes.Add(imageRecette);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageRecette", new { id = imageRecette.IdPhoto }, imageRecette);
        }

        // DELETE: api/ImageRecettes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageRecette(int id)
        {
            var imageRecette = await _context.ImageRecettes.FindAsync(id);
            if (imageRecette == null)
            {
                return NotFound();
            }

            _context.ImageRecettes.Remove(imageRecette);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageRecetteExists(int id)
        {
            return _context.ImageRecettes.Any(e => e.IdPhoto == id);
        }
    }
}
