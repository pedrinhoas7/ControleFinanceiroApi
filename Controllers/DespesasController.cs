#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.Data;
using ControleFinanceiro.Entity;

namespace ControleFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        private readonly ControleFinanceiroContext _context;

        public DespesasController(ControleFinanceiroContext context)
        {
            _context = context;
        }

        // GET: api/Despesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Despesas>>> GetDespesas()
        {
            return await _context.Despesas.ToListAsync();
        }

        // GET: api/Despesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Despesas>> GetDespesas(int id)
        {
            var despesas = await _context.Despesas.FindAsync(id);

            if (despesas == null)
            {
                return NotFound();
            }

            return despesas;
        }

        // GET: api/Despesas/{descricao}
        [HttpGet("descricao")]
        public async Task<ActionResult<Despesas>> GetDespesasDescription(string descricao)
        {
            var despesas = await _context.Despesas.Where(despesas => despesas.Description == descricao).ToListAsync();

            if (despesas == null)
            {
                return NotFound();
            }

            return Ok(despesas);
        }

        // GET: api/Despesas/{ano}/{mes}
        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult<Despesas>> GetDespesasData(int ano, int mes)
        {
            var dateInit = new DateTime(ano,  mes , 01);
            var dateFinal = dateInit.AddMonths(1).AddDays(-1).AddHours(23.999999);
            var despesas = await _context.Despesas.Where(despesas => despesas.Date >= dateInit & despesas.Date <= dateFinal ).ToListAsync();

            if (despesas == null)
            {
                return NotFound();
            }

            return Ok(despesas);
        }

        // PUT: api/Despesas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespesas(int id, Despesas despesas)
        {
            if (id != despesas.Id)
            {
                return BadRequest();
            }

            _context.Entry(despesas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DespesasExists(id))
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

        // POST: api/Despesas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Despesas>> PostDespesas(Despesas despesas)
        {
            if(despesas.categoria == null)
            {
                despesas.categoria =  Entity.Enum.CategoriaDespesas.Outras;
            }

            _context.Despesas.Add(despesas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDespesas", new { id = despesas.Id }, despesas);
        }

        // DELETE: api/Despesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespesas(int id)
        {
            var despesas = await _context.Despesas.FindAsync(id);
            if (despesas == null)
            {
                return NotFound();
            }

            _context.Despesas.Remove(despesas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DespesasExists(int id)
        {
            return _context.Despesas.Any(e => e.Id == id);
        }
    }
}
