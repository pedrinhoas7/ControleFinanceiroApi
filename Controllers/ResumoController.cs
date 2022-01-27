#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.Data;

namespace ControleFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumoController : ControllerBase
    {
        private readonly ControleFinanceiroContext _context;

        public ResumoController(ControleFinanceiroContext context)
        {
            _context = context;
        }

        // GET: api/Despesas
        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult> GetResumo(int mes, int ano)
        {
            var dateInit = new DateTime(ano, mes, 01);
            var dateFinal = dateInit.AddMonths(1).AddDays(-1).AddHours(23.9999);

            var despesas = await _context.Despesas.ToListAsync();
            double[] despesasTotalCategoria = new double[8];
            var despesasTotal = 0.00;

            var receitas = await _context.Receitas.ToListAsync();
            var receitasTotal = 0.00;

            //retorna as despesas por mes e por categoria
            foreach (var despesa in despesas)
            {
                if(despesa.Date >= dateInit & despesa.Date <= dateFinal)
                {
                    despesasTotal = +despesa.Value;
                    despesasTotalCategoria[(int)despesa.categoria] = +despesa.Value;
                }
                    

            }

            //retorna as receitas por mes
            foreach(var receita in receitas)
            {
                if(receita.Date >= dateInit & receita.Date <= dateFinal)
                    receitasTotal = +receita.Value;
            }

            //total (receitas - despesas)
            var valorLiquido = receitasTotal - despesasTotal;



            return Ok($"Total de receitas : {receitasTotal} \n" +
                $"Total de despesas : {despesasTotal} \n" +
                $"Saldo Final : {valorLiquido}\n" +
                $"Total de despesas por categoria" +
                $"Alimentação: {despesasTotalCategoria[0]}\n" +
                $"Saúde: {despesasTotalCategoria[1]}\n" +
                $"Moradia: {despesasTotalCategoria[2]}\n" +
                $"Transporte: {despesasTotalCategoria[3]}\n" +
                $"Educação: {despesasTotalCategoria[4]}\n" +
                $"Lazer: {despesasTotalCategoria[5]}\n" +
                $"Imprevistos: {despesasTotalCategoria[6]}\n" +
                $"Outros: {despesasTotalCategoria[7]}");

            
        }




    }
}
