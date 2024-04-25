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

        private readonly IHttpRepository _http;
        public TransacaoFinanceiraUseCase(IHttpRepository http,
            IClienteService clienteService,
            IContaService contaService)
        {

            _http = http;
            _clienteService = clienteService;
            _contaService = contaService;
        }


        public async Task RealizarTransacao(TransferenciaRequest requisicaoTransacao, CancellationToken token = default)
        {
            await this._clienteService.Validar($"{_enderecoBaseUrl}clientes/{requisicaoTransacao.IdCliente}", token);
            await this._contaService.Validar($"{this._enderecoBaseUrl}contas/", requisicaoTransacao.Conta.IdOrigem.ToString(),
                requisicaoTransacao.Conta.IdDestino.ToString(), requisicaoTransacao.Valor);
            

            //await this.atualizarSaldo("http://localhost:9090/contas/saldos", requisicaoTransacao);
            await this.enviarTransacao("http://localhost:8080/transferencia", requisicaoTransacao);

        }


        

        private async Task<TResposta?> obterValorRequisicao<TResposta>(string url, TransferenciaRequest requisicaoTransacao) where TResposta : class
        {
            return await this._http.ObterAsync<TResposta>(url);
            //var contaOrigemRequest = await this._http.ObterAsync<TResposta>(url);
            //return await obterRespostaHttp<TResposta>(contaOrigemRequest);

        }

        private async Task enviarTransacao(string url, TransferenciaRequest requisicaoTransacao)
        {
            var httpResponse = await this._http.EnviarPostAsync(url, JsonSerializer.Serialize(requisicaoTransacao));
            //if (httpResponse == null || !httpResponse.IsSuccessStatusCode)
            //    throw new Exception("Não foi possível realizar a transação");
        }






        private async Task<TResposta> obterRespostaHttp<TResposta>(HttpResponseMessage respostaHttp)
        {


            if (!respostaHttp.IsSuccessStatusCode)
                throw new Exception($"Requisicao inválida");

            var conteudo = await respostaHttp.Content.ReadFromJsonAsync<TResposta>();

            if (conteudo == null)
                throw new Exception("Resposta inválida");

            return conteudo;
        }






    }
}
