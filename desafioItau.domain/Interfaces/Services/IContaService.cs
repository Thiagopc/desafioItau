using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Interfaces.Services
{
    public interface IContaService
    {
        public Task Validar(string url, string parametroIdOrigem, string parametroIdDestino, decimal valor);
    }
}
