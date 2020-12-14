
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


        [Theory]
        [InlineData(100)]
        [InlineData(200)]
        public void Get_CalculoDoValorFinal_DeveRetornarValorAcimaDoInicial(double valorInicial)
        {
            var configuration = new ConfigurationBuilder()
                                .AddInMemoryCollection()
                                .Build();

            var calculadorServico = new CalculadorServico(configuration);
            var montante = calculadorServico.CalcularMontanteMensal(0.01, 5);

            var valorFinalComJuros = valorInicial * montante;

            valorFinalComJuros.Should().BeGreaterThan(valorInicial, because: "O valor final não está como esperado.");

        }

    }
}
