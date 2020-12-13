
using bidorprojetocore.API.Controllers;
using bidorprojetocore.API.Dominios;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace bidorprojetocore.TestesUnitario
{
    public class CalculadorControllerTeste : IClassFixture<WebApplicationFactory<API.Startup>>
    {

        private readonly WebApplicationFactory<API.Startup> _factory;

        public CalculadorControllerTeste(WebApplicationFactory<API.Startup> factory)
        {
            _factory = factory;
        }

            
        [Fact]
        public void Get_CalculoDoValorFinal_DeveRetornarValorAcimaDoInicial()
        {
            double valorinicial = 100;
            int meses = 5;

            var clientHttp = _factory.CreateClient();

            var retornoJuros = clientHttp.GetAsync($"https://localhost:44346/api/calculador/calculajuros?valorinicial={valorinicial}&meses={meses}").Result;

            var juros = Convert.ToDouble(retornoJuros.Content.ReadAsStringAsync().Result, CultureInfo.GetCultureInfo("pt-br"));
            
            juros.Should().BeGreaterThan(100, because: "Valor informado do montante");

        }

    }
}
