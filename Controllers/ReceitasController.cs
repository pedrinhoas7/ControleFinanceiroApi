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
        public async Task<ActionResult<Receitas>> GetReceitas(string id)
        {
            var receitas = await _context.Receitas.FindAsync(id);

            if (receitas == null)
            {
                return NotFound();
            }

            return receitas;
        }

        // PUT: api/Receitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceitas(string id, Receitas receitas)
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
        public async Task<IActionResult> DeleteReceitas(string id)
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

        private bool ReceitasExists(string id)
        {
            return _context.Receitas.Any(e => e.Id == id);
        }
    }
}
