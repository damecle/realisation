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
    public class ImageIngredientsController : ControllerBase
    {
        private readonly DbAppContext _context;

        public ImageIngredientsController(DbAppContext context)
        {
            _context = context;
        }

        // GET: api/ImageIngredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageIngredient>>> GetImageIngredients()
        {
            return await _context.ImageIngredients.ToListAsync();
        }

        // GET: api/ImageIngredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageIngredient>> GetImageIngredient(int id)
        {
            var imageIngredient = await _context.ImageIngredients.FindAsync(id);

            if (imageIngredient == null)
            {
                return NotFound();
            }

            return imageIngredient;
        }

        // PUT: api/ImageIngredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageIngredient(int id, ImageIngredient imageIngredient)
        {
            if (id != imageIngredient.IdPhoto)
            {
                return BadRequest();
            }

            _context.Entry(imageIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageIngredientExists(id))
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

        // POST: api/ImageIngredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageIngredient>> PostImageIngredient(ImageIngredient imageIngredient)
        {
            _context.ImageIngredients.Add(imageIngredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageIngredient", new { id = imageIngredient.IdPhoto }, imageIngredient);
        }

        // DELETE: api/ImageIngredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageIngredient(int id)
        {
            var imageIngredient = await _context.ImageIngredients.FindAsync(id);
            if (imageIngredient == null)
            {
                return NotFound();
            }

            _context.ImageIngredients.Remove(imageIngredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageIngredientExists(int id)
        {
            return _context.ImageIngredients.Any(e => e.IdPhoto == id);
        }
    }
}
