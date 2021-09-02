﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coreWebAPI.Models;

namespace coreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ReservationContext _context;

        public PeopleController(ReservationContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            var OldPerson = await _context.People.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            var OldMass = await _context.Masses.AsNoTracking().FirstOrDefaultAsync(m => m.MassId == OldPerson.MassId);
            var NewMass = await _context.Masses.AsNoTracking().FirstOrDefaultAsync(m => m.MassId == person.MassId);
            _context.Entry(person).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                OldMass.currentSeats += 1;
                _context.Entry(OldMass).State = EntityState.Modified;

                NewMass.currentSeats -= 1;
                _context.Entry(NewMass).State = EntityState.Modified;

                await _context.SaveChangesAsync();

               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            var Mass = await _context.Masses.FindAsync(person.MassId);
            Mass.currentSeats -= 1;
           //_context.Entry(Mass).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            var Mass = await _context.Masses.FindAsync(person.MassId);
            Mass.currentSeats += 1;
            await _context.SaveChangesAsync();

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
