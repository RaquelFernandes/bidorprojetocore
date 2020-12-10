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
        private IConfiguration _configuration;

        public CalculadorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("calculajuros")]
        public IActionResult CalcularJurosComposto(double valorinicial, int meses)
        {
            double valorDoJurosMensal = (double)ValorDoJurosMensal();

            if (valorDoJurosMensal == 0)
            {
                return NoContent();
            }

            var juros = 1 + valorDoJurosMensal;
            var montante = Math.Pow(juros, meses);

            var valorDoJurosComposto = valorinicial * montante;
            return Ok(valorDoJurosComposto.ToString("N2"));
        }

        private decimal ValorDoJurosMensal()
        { 
            string urlBaseDaAPIDeJuros = _configuration.GetValue<string>("UrlBaseDaAPI:BaseAPIDeJuros");

            HttpClient httpClient = new HttpClient();
            var juros = httpClient.GetAsync($"{urlBaseDaAPIDeJuros}api/juros/taxaJuros").Result;
            if (juros.IsSuccessStatusCode)
            {
                var valor = juros.Content.ReadAsStringAsync().Result;
                return Convert.ToDecimal(valor, CultureInfo.GetCultureInfo("en-us"));
            }

            return 0;
        }
    }
}
