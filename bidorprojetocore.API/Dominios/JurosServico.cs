using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace bidorprojetocore.API.Dominios
{
    public class JurosServico : IJurosServico
    {
        private IConfiguration _configuration;

        public JurosServico(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public double RecuperarTaxaDeJurosMensal()
        {
            var taxaPorMes = _configuration.GetValue<string>("TaxaDeJuros:TaxaPorMes");

            var taxa = Convert.ToDouble(taxaPorMes, CultureInfo.GetCultureInfo("pt-br"));

            return taxa;
        }
    }
}
