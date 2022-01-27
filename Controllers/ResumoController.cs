#nullable disable
using Microsoft.AspNetCore.Mvc;
using ControleFinanceiro.Services;

namespace ControleFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumoController : ControllerBase
    {
        private readonly ResumoService _service;

        public ResumoController(ResumoService service)
        {
            _service = service;
        }


        // GET: api/Despesas
        [HttpGet("{ano}/{mes}")]
        public string GetResumo(int mes, int ano)
        {
            var dateInit = new DateTime(ano, mes, 01);
            var dateFinal = dateInit.AddMonths(1).AddDays(-1).AddHours(23.9999);

            var result =  _service.getResumoTostring(dateInit, dateFinal);

            return result;
        }



    }
}
