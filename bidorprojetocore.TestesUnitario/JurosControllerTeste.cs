using bidorprojetocore.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Globalization;
using Xunit;

namespace bidorprojetocore.TestesUnitario
{
    public class JurosControllerTeste : IClassFixture<WebApplicationFactory<API.Startup>>
    {
        private readonly WebApplicationFactory<API.Startup> _factory;

        public JurosControllerTeste(WebApplicationFactory<API.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void Get_RecuperarValorDoJuros_DeveSerIgualAoDefinido()
        {
            var client = _factory.CreateClient();
            var resultadoresponse = client.GetAsync($"https://localhost:44346/api/juros/taxaJuros").Result;

            var valorDoJuros = Convert.ToDouble(resultadoresponse.Content.ReadAsStringAsync().Result, CultureInfo.GetCultureInfo("pt-br"));

            valorDoJuros.Should().Be(0.01, because: "O valor do juros não corresponde ao esperado");
        }

        [Fact]
        public void Get_RecuperarValorDoJuros_NãoPodeSerZero()
        {
            var client = _factory.CreateClient();
            var resultadoresponse = client.GetAsync($"https://localhost:44346/api/juros/taxaJuros").Result;

            var valorDoJuros = Convert.ToDouble(resultadoresponse.Content.ReadAsStringAsync().Result, CultureInfo.GetCultureInfo("pt-br"));

            valorDoJuros.Should().NotBe(0, because: "O valor do juros não pode ser 0.");
        }

    }
}
