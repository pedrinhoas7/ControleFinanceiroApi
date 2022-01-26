using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Entity
{
    [Table("receitas")]
    public class Receitas
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime Date { get; set; }

        public Receitas()
        {
        }

        public Receitas(int id, string description, double value, DateTime date)
        {
            Id = id;
            Description = description;
            Value = value;
            Date = date;
        }
    }
}
