using desafioItau.application.Dto.Request;
using desafioItau.application.Dto.Response;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace desafioItau.domain.Services
{
    public class ContaService : BaseService, IContaService
    {

        public ContaService(IHttpRepository clientehttp) : base(clientehttp) { }

        
        public async Task Validar(string url, string parametroIdOrigem, string parametroIdDestino, decimal valor)
        {
            var contaOrigem = await this._clientehttp.ObterAsync<ContaResponse>($"{url}/{parametroIdOrigem}");
            var contaDestino = await this._clientehttp.ObterAsync<ContaResponse>($"{url}/{parametroIdDestino}");
            this.validar(contaOrigem, contaDestino, valor);
        }


        public async Task AtualizarSaldo(string url, TransferenciaRequest requisicaoTransferencia)
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
            await this._clientehttp.EnviarPutAsync(url, dadosTransferencia);           

        }

        private void validar(ContaResponse contaOrigem, ContaResponse contaDestino, decimal valor)
        {
            if (contaOrigem == null || contaDestino == null)
                throw new ArgumentNullException("Conta origem ou conta destino nula");


            if (!contaOrigem.Ativo)
                throw new Exception($"Conta de origem: ${contaOrigem.Id} está inativa");

            if (!contaDestino.Ativo)
                throw new Exception($"Conta de destino: ${contaDestino.Id} está inativa");

            if (contaOrigem.Saldo < valor)
                throw new Exception("Transacao não autorizada. Saldo insuficiente");

            if (contaOrigem.LimiteDiario == 0 || contaOrigem.LimiteDiario < valor)
                throw new Exception("Transação não autorizada. Motivo: Limite diário");
        }
    }
}
