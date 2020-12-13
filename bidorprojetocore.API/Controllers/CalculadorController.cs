using bidorprojetocore.API.Dominios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace bidorprojetocore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadorController : ControllerBase
    {
        private ICalculadorServico _calculadorServico;

        public CalculadorController(ICalculadorServico calculadorServico)
        {
            _calculadorServico = calculadorServico;
        }

        [HttpGet("calculajuros")]
        public IActionResult CalcularJurosComposto(double valorinicial, int meses)
        {
            double valorDoJurosMensal = _calculadorServico.ValorDoJurosMensal();

            double montante = _calculadorServico.CalcularMontanteMensal(valorDoJurosMensal, meses);

            var valorDoJurosComposto = valorinicial * montante;
            return Ok(valorDoJurosComposto.ToString("N2"));
        }

    }
}
