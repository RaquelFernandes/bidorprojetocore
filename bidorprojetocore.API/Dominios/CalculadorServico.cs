using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace bidorprojetocore.API.Dominios
{
    public class CalculadorServico : ICalculadorServico
    {
        private IConfiguration _configuration;

        public CalculadorServico(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public double CalcularMontanteMensal(double valorDoJurosMensal, int meses)
        {
            var juros = 1 + valorDoJurosMensal;
            var montante = Math.Pow(juros, meses);
            return montante;
        }

        public double ValorDoJurosMensal()
        {
            string urlBaseDaAPIDeJuros = _configuration.GetValue<string>("UrlBaseDaAPI:BaseAPIDeJuros");

            HttpClient httpClient = new HttpClient();
            var juros = httpClient.GetAsync($"{urlBaseDaAPIDeJuros}api/juros/taxaJuros").Result;

            if (juros.IsSuccessStatusCode)
            {
                var valor = juros.Content.ReadAsStringAsync().Result;
                return Convert.ToDouble(valor, CultureInfo.GetCultureInfo("pt-br"));
            }

            return 0;
        }
    }
}
