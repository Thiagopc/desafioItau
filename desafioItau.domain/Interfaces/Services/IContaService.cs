using desafioItau.application.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Interfaces.Services
{
    public interface IContaService
    {
        public Task ValidarSolicitacao(string url, string parametroIdOrigem, string parametroIdDestino, decimal valor);
        Task AtualizarSaldo(string url, TransferenciaRequest requisicaoTransferencia);
    }
}
