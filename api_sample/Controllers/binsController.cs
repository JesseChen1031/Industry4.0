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
    [Route("api/[controller]")]
    [ApiController]
    public class binsController : ControllerBase
    {
        private readonly TodoContext _context;

        public binsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/bins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<bin>>> Getbins()
        {
            return await _context.bins.ToListAsync();
        }

        // GET: api/bins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<bin>> Getbin(int id)
        {
            var bin = await _context.bins.FindAsync(id);

            if (bin == null)
            {
                return NotFound();
            }

            return bin;
        }

        // PUT: api/bins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbin(int id, bin bin)
        {
            if (id != bin.id)
            {
                return BadRequest();
            }

            _context.Entry(bin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!binExists(id))
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

        // POST: api/bins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<bin>> Postbin(bin bin)
        {
            _context.bins.Add(bin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbin", new { id = bin.id }, bin);
        }

        // DELETE: api/bins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bin>> Deletebin(int id)
        {
            var bin = await _context.bins.FindAsync(id);
            if (bin == null)
            {
                return NotFound();
            }

            _context.bins.Remove(bin);
            await _context.SaveChangesAsync();

            return bin;
        }

        private bool binExists(int id)
        {
            return _context.bins.Any(e => e.id == id);
        }
    }
}
