using desafioItau.application.Dto.Request;
using desafioItau.application.Dto.Response;
using desafioItau.domain.Entities;
using desafioItau.domain.Enum;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.domain.Interfaces.Services;


namespace desafioItau.domain.Services
{
    public class ContaService : BaseService, IContaService
    {

        public ContaService(IHttpRepository clientehttp, IRepositoryDbBase<Historico> repositorioHistorico)
            : base(clientehttp, repositorioHistorico) { }


        public async Task ValidarSolicitacao(string url, string parametroIdOrigem, string parametroIdDestino, decimal valor)
        {
            var contaOrigem = await obterConta($"{url}/{parametroIdOrigem}");
            var contaDestino = await obterConta($"{url}/{parametroIdDestino}");
            this.validar(contaOrigem, contaDestino, valor);
        }


        public async Task AtualizarSaldo(string url, TransferenciaRequest requisicaoTransferencia, string identificadorTransferencia)
        {


            var dadosTransferencia = new DadosContaRequest
            {
                Valor = requisicaoTransferencia.Valor,
                Conta = new InformacaoContaRequest
                {
                    IdDestino = requisicaoTransferencia.Conta.IdDestino,
                    IdOrigem = requisicaoTransferencia.Conta.IdOrigem
                }
            };

            await this.salvarHistorico(EnumHistoricoTransacao.Iniciado, FakeEnumOperacaoTransacao.AtualizarSaldo, identificadorTransferencia);            
            await this._clientehttp.EnviarPutAsync(url, dadosTransferencia);
            await this.salvarHistorico(EnumHistoricoTransacao.Finalizado, FakeEnumOperacaoTransacao.AtualizarSaldo, identificadorTransferencia);

        }

        private void validar(ContaResponse contaOrigem, ContaResponse contaDestino, decimal valor)
        {
            if (contaOrigem == null || contaDestino == null)
                throw new ArgumentNullException("Conta origem ou conta destino nula");


            if (!contaOrigem.Ativo)
                throw new Exception($"Conta de origem está inativa");

            if (!contaDestino.Ativo)
                throw new Exception($"Conta de destino está inativa");

            if (contaOrigem.Saldo < valor)
                throw new Exception("Transacao não autorizada. Saldo insuficiente");

            if (contaOrigem.LimiteDiario == 0 || contaOrigem.LimiteDiario < valor)
                throw new Exception("Transação não autorizada. Motivo: Limite diário");
        }

        private async Task<ContaResponse?> obterConta(string url)
           => await this._clientehttp.ObterAsync<ContaResponse>(url);

    }
}
