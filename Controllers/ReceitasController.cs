#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.Data;
using ControleFinanceiro.Entity;

namespace ControleFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly ControleFinanceiroContext _context;

        public ReceitasController(ControleFinanceiroContext context)
        {
            _context = context;
        }

        // GET: api/Receitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receitas>>> GetReceitas()
        {
            return await _context.Receitas.ToListAsync();
        }

        // GET: api/Receitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receitas>> GetReceitas(int id)
        {
            var receitas = await _context.Receitas.FindAsync(id);

            if (receitas == null)
            {
                return NotFound();
            }

            return receitas;
        }

        // GET: api/Receitas/{descricao}
        [HttpGet("descricao")]
        public async Task<ActionResult<Receitas>> GetReceitasDescription(string descricao)
        {
            var receitas = await _context.Receitas.Where(receitas => receitas.Description == descricao).ToListAsync() ;

            if (receitas == null)
            {
                return NotFound();
            }

            return Ok(receitas);
        }

        // GET: api/Receitas/{ano}/{mes}}
        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult<Receitas>> GetReceitasData(int ano, int mes)
        {
            var dateInit = new DateTime(ano, mes, 01);
            var dateFinal = dateInit.AddMonths(1).AddDays(-1).AddHours(23.999999);
            var receitas = await _context.Receitas.Where(receitas => receitas.Date >= dateInit & receitas.Date <= dateFinal).ToListAsync();

            if (receitas == null)
            {
                return NotFound();
            }

            return Ok(receitas);
        }

        // PUT: api/Receitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceitas(int id, Receitas receitas)
        {
            if (id != receitas.Id)
            {
                return BadRequest();
            }

            _context.Entry(receitas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceitasExists(id))
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

        // POST: api/Receitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Receitas>> PostReceitas(Receitas receitas)
        {
            _context.Receitas.Add(receitas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReceitasExists(receitas.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReceitas", new { id = receitas.Id }, receitas);
        }

        // DELETE: api/Receitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceitas(int id)
        {
            var receitas = await _context.Receitas.FindAsync(id);
            if (receitas == null)
            {
                return NotFound();
            }

            _context.Receitas.Remove(receitas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceitasExists(int id)
        {
            return _context.Receitas.Any(e => e.Id == id);
        }
    }
}
