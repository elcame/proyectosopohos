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
    public class HeroesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HeroesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Heroe>>> GetHeroes()
        {
            return await _context.Heroes.ToListAsync();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Heroe>> GetHeroe(int id)
        {
            var heroe = await _context.Heroes.FindAsync(id);

            if (heroe == null)
            {
                return NotFound();
            }

            return heroe;
        }

        // PUT: api/Heroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroe(int id, Heroe heroe)
        {
            if (id != heroe.IdHero)
            {
                return BadRequest();
            }

            _context.Entry(heroe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroeExists(id))
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

        // GET: api/Relaciones/5
        [HttpGet("{idR}")]
        public async Task<ActionResult<Heroe>> GetRelacione(int idR)
        {
            // var relacione = await _context.Relaciones.Include(x=>x.IdHeroNavigation.IdHero).FirstAsync(x=>x.IdRelacion.Equals(id));
            var relacion = await _context.Heroes.Select(x => x.Relaciones.);

            var relacione = await _context.Relaciones.FindAsync(idR);
            if (relacione == null)
            {

                return NotFound();
            }
           var valor= await GetHeroe(relacione.IdHero.Value); 


            return valor;
        }

        // POST: api/Heroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Heroe>> PostHeroe(Heroe heroe)
        {
            _context.Heroes.Add(heroe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeroe", new { id = heroe.IdHero }, heroe);
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroe(int id)
        {
            var heroe = await _context.Heroes.FindAsync(id);
            if (heroe == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(heroe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroeExists(int id)
        {
            return _context.Heroes.Any(e => e.IdHero == id);
        }
    }
}
