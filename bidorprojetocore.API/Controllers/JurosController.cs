using bidorprojetocore.API.Dominios;
using Microsoft.AspNetCore.Mvc;

namespace bidorprojetocore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JurosController : ControllerBase
    {
        private IJurosServico _jurosServico;

        public JurosController(IJurosServico jurosServico)
        {
            _jurosServico = jurosServico;
        }

        [HttpGet("taxaJuros")]
        public IActionResult TaxaDeJuros()
        {
            var taxaPorMes = _jurosServico.RecuperarTaxaDeJurosMensal();
            return Ok(taxaPorMes.ToString());
        }
    }
}
