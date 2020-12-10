using bidorprojetocore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace bidorprojetocore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JurosController : ControllerBase
    {
        private IConfiguration _configuration;

        public JurosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("taxaJuros")]
        public IActionResult Index()
        {
            var taxaPorMes = _configuration.GetValue<string>("TaxaDeJuros:TaxaPorMes");
            return Ok(Convert.ToDecimal(taxaPorMes, CultureInfo.GetCultureInfo("en-us")));
        }
    }
}
