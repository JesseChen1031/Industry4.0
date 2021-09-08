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

    


    public class deviceOWsController : ControllerBase
    {
        private readonly TodoContext _context;

        

        public deviceOWsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/deviceOWs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<deviceOW>>> GetdeviceOWs()
        {
            return await _context.deviceOWs.ToListAsync();
        }

        // GET: api/deviceOWs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<deviceOW>> GetdeviceOW(int id)
        {
            var deviceOW = await _context.deviceOWs.FindAsync(id);

            if (deviceOW == null)
            {
                return NotFound();
            }

            return deviceOW;
        }

        // PUT: api/deviceOWs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdeviceOW(int id, deviceOW deviceOW)
        {
            if (id != deviceOW.id)
            {
                return BadRequest();
            }

            _context.Entry(deviceOW).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!deviceOWExists(id))
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

        // POST: api/deviceOWs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<deviceOW>> PostdeviceOW(deviceOW deviceOW)
        {
            _context.deviceOWs.Add(deviceOW);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetdeviceOW", new { id = deviceOW.id }, deviceOW);
        }

        // DELETE: api/deviceOWs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<deviceOW>> DeletedeviceOW(int id)
        {
            var deviceOW = await _context.deviceOWs.FindAsync(id);
            if (deviceOW == null)
            {
                return NotFound();
            }

            _context.deviceOWs.Remove(deviceOW);
            await _context.SaveChangesAsync();

            return deviceOW;
        }

        private bool deviceOWExists(int id)
        {
            return _context.deviceOWs.Any(e => e.id == id);
        }
    }
}
