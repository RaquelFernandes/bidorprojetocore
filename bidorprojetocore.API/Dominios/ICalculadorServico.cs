using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidorprojetocore.API.Dominios
{
    public interface ICalculadorServico
    {
        double ValorDoJurosMensal();
        double CalcularMontanteMensal(double juros, int meses);
    }
}
