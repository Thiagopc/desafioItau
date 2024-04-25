using desafioItau.application.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.application.Interfaces.UseCase
{
    public interface ITransacaoFinanceiraUseCase
    {
        Task RealizarTransacao(TransferenciaRequest requisicao, CancellationToken token = default);
    }
}
