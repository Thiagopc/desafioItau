using desafioItau.domain.Interfaces.Repositories;
using desafioItau.infra.Politicas;
using Polly.Retry;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace desafioItau.infra.Repositories.ClasseBase
{
    public class HttpRepository : IHttpRepository
    {
        private readonly IHttpClientFactory _httpfactory;
        private readonly string _mediaType = "application/json";


        private AsyncRetryPolicy<HttpResponseMessage> _politicaRetryTimeout;
        public HttpRepository(IHttpClientFactory httpfactory)
        {
            this._httpfactory = httpfactory;
            this._politicaRetryTimeout = PoliticaHttp.RetryAsync();
        }


        public async Task<TConteudo?> ObterAsync<TConteudo>(string url, CancellationToken token = default) where TConteudo : class

        {
            using (var clienteHttp = this._httpfactory.CreateClient())
            {

                var resposta = await this._politicaRetryTimeout.ExecuteAsync(async (token) => await clienteHttp.GetAsync(url),
                    token);

                resposta.EnsureSuccessStatusCode();
                return await resposta.Content.ReadFromJsonAsync<TConteudo>();
            }

        }

        public async Task EnviarPostAsync<TConteudo>(string url, TConteudo conteudoRequisicao) where TConteudo : class
        {
            using (var clienteHttp = this._httpfactory.CreateClient())
            {
                var resposta = await this._politicaRetryTimeout.
                    ExecuteAsync(async () =>
                    {
                        return await clienteHttp
                            .PostAsync(url, this.obterStringContent<TConteudo>(conteudoRequisicao));

                    });
                resposta.EnsureSuccessStatusCode();

                //return await resposta.Content.ReadFromJsonAsync<TConteudo>();
            }
        }


        public async Task EnviarPutAsync<TConteudo>(string url, TConteudo conteudoRequisicao) where TConteudo : class
        {
            using (var clienteHttp = this._httpfactory.CreateClient())
            {
                var resposta = await this._politicaRetryTimeout.
                    ExecuteAsync(async () =>
                    {
                        return await clienteHttp.PutAsync(url, this.obterStringContent<TConteudo>(conteudoRequisicao));

                    });

                resposta.EnsureSuccessStatusCode();
            }
        }



        private StringContent obterStringContent<TConteudo>(TConteudo conteudo) where TConteudo : class
            => new StringContent(JsonSerializer.Serialize(conteudo), Encoding.UTF8, this._mediaType);

        private TConteudo? obterClasse<TConteudo>(string conteudoJson) where TConteudo : class
           => JsonSerializer.Deserialize<TConteudo>(conteudoJson);

    }
}
