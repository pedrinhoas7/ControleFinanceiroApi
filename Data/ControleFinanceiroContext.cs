#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.Entity;

namespace ControleFinanceiro.Data
{
    public class ControleFinanceiroContext : DbContext
    {
        public ControleFinanceiroContext (DbContextOptions<ControleFinanceiroContext> options)
            : base(options)
        {
        }

        public DbSet<ControleFinanceiro.Entity.Despesas> Despesas { get; set; }

        public DbSet<ControleFinanceiro.Entity.Receitas> Receitas { get; set; }

        public DbSet<ControleFinanceiro.Entity.User> User { get; set; }
    }
}
