using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coreWebAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MassesController : ControllerBase
    {
        private readonly ReservationContext _context;

        public MassesController(ReservationContext context)
        {
            _context = context;
        }

        // GET: api/Masses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mass>>> GetMasses()
        {
            return await _context.Masses.ToListAsync();
        }

        // GET: api/Masses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mass>> GetMass(int id)
        {
            var mass = await _context.Masses.FindAsync(id);

            if (mass == null)
            {
                return NotFound();
            }

            return mass;
        }

        // PUT: api/Masses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMass(int id, Mass mass)
        {
            if (id != mass.MassId)
            {
                return BadRequest();
            }

            _context.Entry(mass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MassExists(id))
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

        // POST: api/Masses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mass>> PostMass(Mass mass)
        {
            _context.Masses.Add(mass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMass", new { id = mass.MassId }, mass);
        }

        // DELETE: api/Masses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMass(int id)
        {
            var mass = await _context.Masses.FindAsync(id);
            if (mass == null)
            {
                return NotFound();
            }

            _context.Masses.Remove(mass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MassExists(int id)
        {
            return _context.Masses.Any(e => e.MassId == id);
        }
    }
}
