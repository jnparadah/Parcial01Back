using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial01Back.Models;

namespace Parcial01Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DueniosController : ControllerBase
    {
        private readonly Parcial01Context _context;

        public DueniosController(Parcial01Context context)
        {
            _context = context;
        }

        // GET: api/Duenios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Duenio>>> GetDuenios()
        {
          if (_context.Duenios == null)
          {
              return NotFound();
          }
            return await _context.Duenios.ToListAsync();
        }

        // GET: api/Duenios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Duenio>> GetDuenio(int id)
        {
          if (_context.Duenios == null)
          {
              return NotFound();
          }
            var duenio = await _context.Duenios.FindAsync(id);

            if (duenio == null)
            {
                return NotFound();
            }

            return duenio;
        }

        // PUT: api/Duenios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuenio(int id, Duenio duenio)
        {
            if (id != duenio.IdDuenio)
            {
                return BadRequest();
            }

            _context.Entry(duenio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuenioExists(id))
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

        // POST: api/Duenios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Duenio>> PostDuenio(Duenio duenio)
        {
          if (_context.Duenios == null)
          {
              return Problem("Entity set 'Parcial01Context.Duenios'  is null.");
          }
            _context.Duenios.Add(duenio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DuenioExists(duenio.IdDuenio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDuenio", new { id = duenio.IdDuenio }, duenio);
        }

        // DELETE: api/Duenios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuenio(int id)
        {
            if (_context.Duenios == null)
            {
                return NotFound();
            }
            var duenio = await _context.Duenios.FindAsync(id);
            if (duenio == null)
            {
                return NotFound();
            }

            _context.Duenios.Remove(duenio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DuenioExists(int id)
        {
            return (_context.Duenios?.Any(e => e.IdDuenio == id)).GetValueOrDefault();
        }
    }
}
