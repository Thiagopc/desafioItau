using desafioItau.application.Dto.Request;
using desafioItau.application.Dto.Response;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Services
{
    public class TransacaoService : BaseService, ITransacaoService
    {


        public TransacaoService(IHttpRepository clientehttp) :
            base(clientehttp)
        { }


        public async Task EnviarTransacao(string url, TransferenciaRequest requisicao, CancellationToken token = default)
        => await this._clientehttp.EnviarPostAsync(url, requisicao);


    }
}
