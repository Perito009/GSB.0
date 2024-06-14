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
    public class DomaineDeSpecialitesController : ControllerBase
    {
        private readonly GSB_2024Context _context;

        public DomaineDeSpecialitesController(GSB_2024Context context)
        {
            _context = context;
        }

        // GET: api/DomaineDeSpecialites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DomaineDeSpecialite>>> GetDomaineDeSpecialites()
        {
          if (_context.DomaineDeSpecialites == null)
          {
              return NotFound();
          }
            return await _context.DomaineDeSpecialites.ToListAsync();
        }

        // GET: api/DomaineDeSpecialites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DomaineDeSpecialite>> GetDomaineDeSpecialite(string id)
        {
          if (_context.DomaineDeSpecialites == null)
          {
              return NotFound();
          }
            var domaineDeSpecialite = await _context.DomaineDeSpecialites.FindAsync(id);

            if (domaineDeSpecialite == null)
            {
                return NotFound();
            }

            return domaineDeSpecialite;
        }

        // PUT: api/DomaineDeSpecialites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDomaineDeSpecialite(string id, DomaineDeSpecialite domaineDeSpecialite)
        {
            if (id != domaineDeSpecialite.IdSpecialite)
            {
                return BadRequest();
            }

            _context.Entry(domaineDeSpecialite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DomaineDeSpecialiteExists(id))
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

        // POST: api/DomaineDeSpecialites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DomaineDeSpecialite>> PostDomaineDeSpecialite(DomaineDeSpecialite domaineDeSpecialite)
        {
          if (_context.DomaineDeSpecialites == null)
          {
              return Problem("Entity set 'GSB_2024Context.DomaineDeSpecialites'  is null.");
          }
            _context.DomaineDeSpecialites.Add(domaineDeSpecialite);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DomaineDeSpecialiteExists(domaineDeSpecialite.IdSpecialite))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDomaineDeSpecialite", new { id = domaineDeSpecialite.IdSpecialite }, domaineDeSpecialite);
        }

        // DELETE: api/DomaineDeSpecialites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDomaineDeSpecialite(string id)
        {
            if (_context.DomaineDeSpecialites == null)
            {
                return NotFound();
            }
            var domaineDeSpecialite = await _context.DomaineDeSpecialites.FindAsync(id);
            if (domaineDeSpecialite == null)
            {
                return NotFound();
            }

            _context.DomaineDeSpecialites.Remove(domaineDeSpecialite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DomaineDeSpecialiteExists(string id)
        {
            return (_context.DomaineDeSpecialites?.Any(e => e.IdSpecialite == id)).GetValueOrDefault();
        }
    }
}
