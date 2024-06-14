using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GSB._0.Models;

namespace GSB._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private readonly GSB_2024Context _context;

        public DepartementsController(GSB_2024Context context)
        {
            _context = context;
        }

        // GET: api/Departements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departement>>> GetDepartements()
        {
          if (_context.Departements == null)
          {
              return NotFound();
          }
            return await _context.Departements.ToListAsync();
        }

        // GET: api/Departements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departement>> GetDepartement(string id)
        {
          if (_context.Departements == null)
          {
              return NotFound();
          }
            var departement = await _context.Departements.FindAsync(id);

            if (departement == null)
            {
                return NotFound();
            }

            return departement;
        }

        // PUT: api/Departements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartement(string id, Departement departement)
        {
            if (id != departement.IdDepartement)
            {
                return BadRequest();
            }

            _context.Entry(departement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartementExists(id))
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

        // POST: api/Departements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Departement>> PostDepartement(Departement departement)
        {
          if (_context.Departements == null)
          {
              return Problem("Entity set 'GSB_2024Context.Departements'  is null.");
          }
            _context.Departements.Add(departement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepartementExists(departement.IdDepartement))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDepartement", new { id = departement.IdDepartement }, departement);
        }

        // DELETE: api/Departements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartement(string id)
        {
            if (_context.Departements == null)
            {
                return NotFound();
            }
            var departement = await _context.Departements.FindAsync(id);
            if (departement == null)
            {
                return NotFound();
            }

            _context.Departements.Remove(departement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartementExists(string id)
        {
            return (_context.Departements?.Any(e => e.IdDepartement == id)).GetValueOrDefault();
        }
    }
}
