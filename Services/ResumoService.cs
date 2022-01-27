using ControleFinanceiro.Data;
using ControleFinanceiro.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Services
{
    public class ResumoService 
    {
        private readonly ControleFinanceiroContext _context;

        public ResumoService(ControleFinanceiroContext context)
        {
            _context = context;
        }
        public string getResumoTostring(DateTime dateInit, DateTime dateFinal)
        {
            try
            {
                var despesas = _context.Despesas.ToList();
                double[] despesasTotalCategoria = new double[8];
                var despesasTotal = 0.00;

                var receitas = _context.Receitas.ToList();
                var receitasTotal = 0.00;

                //retorna as despesas por mes e por categoria
                foreach (var despesa in despesas)
                {
                    if (despesa.Date >= dateInit & despesa.Date <= dateFinal)
                    {
                        despesasTotal = despesasTotal + despesa.Value;
                        despesasTotalCategoria[(int)despesa.categoria] = despesasTotalCategoria[(int)despesa.categoria] + despesa.Value;
                    }


                }

                //retorna as receitas por mes
                foreach (var receita in receitas)
                {
                    if (receita.Date >= dateInit & receita.Date <= dateFinal)
                        receitasTotal = receitasTotal + receita.Value;
                }

                //total (receitas - despesas)
                var valorLiquido = receitasTotal - despesasTotal;



                return $"Total de receitas : {receitasTotal} \n" +
                    $"Total de despesas : {despesasTotal} \n" +
                    $"Saldo Final : {valorLiquido}\n \n" +
                    $"Total de despesas por categoria \n"  +
                    $"Alimentação: {despesasTotalCategoria[0]}\n" +
                    $"Saúde: {despesasTotalCategoria[1]}\n" +
                    $"Moradia: {despesasTotalCategoria[2]}\n" +
                    $"Transporte: {despesasTotalCategoria[3]}\n" +
                    $"Educação: {despesasTotalCategoria[4]}\n" +
                    $"Lazer: {despesasTotalCategoria[5]}\n" +
                    $"Imprevistos: {despesasTotalCategoria[6]}\n" +
                    $"Outros: {despesasTotalCategoria[7]}";


            }catch (Exception ex)
            {
                return ex.Message;
            }


         }

    } 

}
