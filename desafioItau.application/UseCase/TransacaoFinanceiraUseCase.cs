using desafioItau.application.Dto.Request;
using desafioItau.application.Dto.Response;
using desafioItau.application.Interfaces.UseCase;
using desafioItau.domain.Entities;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace desafioItau.application.UseCase
{
    public class TransacaoFinanceiraUseCase : ITransacaoFinanceiraUseCase
    {
        private readonly string _enderecoBaseUrl = "http://host.docker.internal:9090";
        private readonly string _enderecoTransferenciaUrl = "http://host.docker.internal:8080";
        private readonly IClienteService _clienteService;
        private readonly IContaService _contaService;
        private readonly ITransacaoService _transacaoService;
        private readonly IRepositoryDbBase<Transacao> _transacaorepo;


        public TransacaoFinanceiraUseCase(
            IClienteService clienteService,
            IContaService contaService,
            ITransacaoService transacaoService,
             IRepositoryDbBase<Transacao> transacaorepo)
        {

            _clienteService = clienteService;
            _contaService = contaService;
            _transacaoService = transacaoService;
            _transacaorepo = transacaorepo;
        }



        
        public async Task RealizarTransacao(TransferenciaRequest requisicaoTransacao,
            string idTransacao)
        {
            await inicializarTransacao(idTransacao);
            _ = await this._clienteService.Obter($"{_enderecoBaseUrl}/clientes/{requisicaoTransacao.IdCliente}");
            await this._contaService.ValidarSolicitacao($"{_enderecoBaseUrl}/contas", requisicaoTransacao.Conta.IdOrigem.ToString(),
                requisicaoTransacao.Conta.IdDestino.ToString(), requisicaoTransacao.Valor);



            await this._contaService.AtualizarSaldo($"{_enderecoBaseUrl}/contas/saldos", requisicaoTransacao, idTransacao);
            await this._transacaoService.EnviarTransacao($"{_enderecoTransferenciaUrl}/transferencia", requisicaoTransacao, idTransacao);


        }


        private async Task inicializarTransacao(string idTransacao)
        {
            if (string.IsNullOrEmpty(idTransacao))
                throw new ArgumentException("Id da transação inválido");

            this._transacaorepo.Adicionar(new Transacao { Id = idTransacao });
            await this._transacaorepo.SalvarAsync();

        }









    }
}
