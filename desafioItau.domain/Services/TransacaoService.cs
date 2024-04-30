using desafioItau.application.Dto.Request;
using desafioItau.application.Dto.Response;
using desafioItau.domain.Entities;
using desafioItau.domain.Enum;
using desafioItau.domain.Interfaces.Evento;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.domain.Interfaces.Services;


namespace desafioItau.domain.Services
{
    public class TransacaoService : BaseService, ITransacaoService
    {

        private readonly IEnvioSQS _evento;

        public TransacaoService(IHttpRepository clientehttp,
            IRepositoryDbBase<Historico> repositorioHistorico,
            IEnvioSQS evento) :
            base(clientehttp, repositorioHistorico)
        { _evento = evento; }


        public async Task EnviarTransacao(string url, TransferenciaRequest requisicao,string idTransacao, CancellationToken token = default)
        {
            await transacao(url, idTransacao, requisicao);
            await notificaEnvioTransferencia(idTransacao, requisicao);
        }


        private async Task transacao(string url, string idTransacao, TransferenciaRequest requisicao)
        {
            await this.salvarHistorico(EnumHistoricoTransacao.Iniciado, FakeEnumOperacaoTransacao.Transferencia, idTransacao);
            await this._clientehttp.EnviarPostAsync(url, requisicao);
            await this.salvarHistorico(EnumHistoricoTransacao.Finalizado, FakeEnumOperacaoTransacao.Transferencia, idTransacao);
        }

        private async Task notificaEnvioTransferencia( string idTransacao, TransferenciaRequest requisicao)
        {
            await this.salvarHistorico(EnumHistoricoTransacao.Iniciado, FakeEnumOperacaoTransacao.NotificaBACEN, idTransacao);
            _evento.Publicar(requisicao);
            await this.salvarHistorico(EnumHistoricoTransacao.Finalizado, FakeEnumOperacaoTransacao.NotificaBACEN, idTransacao);
        }


    }
}
