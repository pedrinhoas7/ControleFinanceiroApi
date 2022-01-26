using ControleFinanceiro.Entity.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Entity
{
    [Table("despesas")]
    public class Despesas
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime Date { get; set; }

        public CategoriaDespesas? categoria { get; set; }

        public Despesas()
        {
        }

        public Despesas(int id, string description, double value, DateTime date)
        {
            Id = id;
            Description = description;
            Value = value;
            Date = date;
        }
    }
}
