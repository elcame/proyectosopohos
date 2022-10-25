using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba.DBContext;
using prueba.Models;

namespace prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelacionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Relaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relacione>>> GetRelaciones()
        {
            return await _context.Relaciones.ToListAsync();
        }

       

        // PUT: api/Relaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelacione(int id, Relacione relacione)
        {
            if (id != relacione.IdRelacion)
            {
                return BadRequest();
            }

            _context.Entry(relacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelacioneExists(id))
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

        // POST: api/Relaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Relacione>> PostRelacione(Relacione relacione)
        {
            _context.Relaciones.Add(relacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRelacione", new { id = relacione.IdRelacion }, relacione);
        }

        // DELETE: api/Relaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelacione(int id)
        {
            var relacione = await _context.Relaciones.FindAsync(id);
            if (relacione == null)
            {
                return NotFound();
            }

            _context.Relaciones.Remove(relacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RelacioneExists(int id)
        {
            return _context.Relaciones.Any(e => e.IdRelacion == id);
        }
    }
}
