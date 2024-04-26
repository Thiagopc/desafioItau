using desafioItau.application.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Interfaces.Services
{
    public interface ITransacaoService
    {
        public Task EnviarTransacao(string url, TransferenciaRequest requisicao, CancellationToken token = default);
    }
}
