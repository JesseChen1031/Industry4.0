using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class materialsController : ControllerBase
    {
        private readonly TodoContext _context;

        public materialsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<material>>> Getmaterials()
        {
            return await _context.materials.ToListAsync();
        }

        // GET: api/materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<material>> Getmaterial(int id)
        {
            var material = await _context.materials.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        [HttpGet("{materialType}")]
        public IEnumerable<material> GetmaterialsByType(int materialType)
        {
            return  _context.materials.Where(p=>p.materialType == materialType);
        }

        // PUT: api/materials/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmaterial(int id, material material)
        {
            if (id != material.id)
            {
                return BadRequest();
            }

            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!materialExists(id))
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

        // POST: api/materials
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<material>> Postmaterial(material material)
        {
            _context.materials.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmaterial", new { id = material.id }, material);
        }

        // DELETE: api/materials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<material>> Deletematerial(int id)
        {
            var material = await _context.materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.materials.Remove(material);
            await _context.SaveChangesAsync();

            return material;
        }

        private bool materialExists(int id)
        {
            return _context.materials.Any(e => e.id == id);
        }
    }
}
