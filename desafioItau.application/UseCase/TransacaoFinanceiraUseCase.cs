using desafioItau.application.Dto.Request;
using desafioItau.application.Dto.Response;
using desafioItau.application.Interfaces.UseCase;
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
        private readonly string _enderecoBaseUrl = "http://localhost:9090/";
        private readonly string _enderecoTransferenciaUrl = "http://localhost:8080/";
        private readonly IClienteService _clienteService;
        private readonly IContaService _contaService;
        private readonly ITransacaoService _transacaoService;


        public TransacaoFinanceiraUseCase(
            IClienteService clienteService,
            IContaService contaService,
            ITransacaoService transacaoService)
        {

            _clienteService = clienteService;
            _contaService = contaService;
            _transacaoService = transacaoService;
        }


        public async Task RealizarTransacao(TransferenciaRequest requisicaoTransacao, CancellationToken token = default)
        {
            _ = await this._clienteService.Obter($"{_enderecoBaseUrl}clientes/{requisicaoTransacao.IdCliente}", token);
            await this._contaService.ValidarSolicitacao($"{this._enderecoBaseUrl}contas/", requisicaoTransacao.Conta.IdOrigem.ToString(),
                requisicaoTransacao.Conta.IdDestino.ToString(), requisicaoTransacao.Valor);


            await this._contaService.AtualizarSaldo("http://localhost:9090/contas/saldos", requisicaoTransacao);
            await this._transacaoService.EnviarTransacao("http://localhost:8080/transferencia", requisicaoTransacao);


        }









    }
}
