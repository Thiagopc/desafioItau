using desafioItau.application.Dto.Response;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.domain.Services;
using desafioItau.test.Repositories;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.test.Build
{
    internal class BuilderContaService
    {



        public static ContaService Builder()
        {
            return new ContaService(new HttpClienteFactoryMock(), new RepositoryDbBaseMoc());

        }



        public class HttpClienteFactoryMock : IHttpRepository
        {


            private Dictionary<string, Task<ContaResponse>> _contaServiceList;

            public HttpClienteFactoryMock()
            {
                _contaServiceList = new Dictionary<string, Task<ContaResponse>>();

                _contaServiceList.Add("/d0d32142-74b7-4aca-9c68-838aeacef96b", Task.FromResult(new ContaResponse
                {
                    Id = new Guid("d0d32142-74b7-4aca-9c68-838aeacef96b"),
                    Ativo = true,
                    LimiteDiario = 500,
                    Saldo = 5000
                }));

                _contaServiceList.Add("/41313d7b-bd75-4c75-9dea-1f4be434007f", Task.FromResult(new ContaResponse
                {
                    Id = new Guid("41313d7b-bd75-4c75-9dea-1f4be434007f"),
                    Ativo = true,
                    LimiteDiario = 500,
                    Saldo = 600
                }));

                // Esta entrada duplicada foi removida para evitar exceção de chave duplicada.
                _contaServiceList.Add("/00313d7b-bd75-4c75-9dea-1f4be434007f", Task.FromResult(new ContaResponse
                {
                    Id = new Guid("00313d7b-bd75-4c75-9dea-1f4be434007f"),
                    Ativo = false,
                    LimiteDiario = 500,
                    Saldo = 600
                }));
            }


            public Task EnviarPostAsync<TConteudo>(string url, TConteudo conteudoRequisicao) where TConteudo : class
            {
                return Task.CompletedTask;
            }

            public Task EnviarPutAsync<TConteudo>(string url, TConteudo conteudoRequisicao) where TConteudo : class
            {
                return Task.CompletedTask;
            }

            public Task<TConteudo?> ObterAsync<TConteudo>(string url) where TConteudo : class
            {
                return _contaServiceList[url] as Task<TConteudo>;
            }
        }



        public class HttpFactoryContaMoc : IHttpClientFactory
        {
            private readonly string _mediaType = @"application/json";
            private string url;
            private string contentJson;
            private int statusCode = 200;
            public HttpFactoryContaMoc(string url, string contentJson, int statusCode = 200)
            {
                this.url = url;
                this.contentJson = contentJson;
                this.statusCode = statusCode;
            }


            public HttpClient CreateClient(string url)
            {
                var mockHttp = new MockHttpMessageHandler();
                if (string.IsNullOrEmpty(contentJson))
                    mockHttp.When(url).Respond((HttpStatusCode)statusCode);
                else
                    mockHttp.When(url).Respond((HttpStatusCode)statusCode, _mediaType, contentJson);

                return new HttpClient(mockHttp);
            }


        }



    }
}
