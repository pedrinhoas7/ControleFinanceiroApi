using ControleFinanceiro.Data;
using ControleFinanceiro.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Services
{
    public class DespesaService
    {
        private readonly ControleFinanceiroContext _context;

        public DespesaService(ControleFinanceiroContext context)
        {
            _context = context;
        }
        

    }

}
