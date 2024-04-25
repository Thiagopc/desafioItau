using Polly;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace desafioItau.infra.Politicas
{
    internal static class PoliticaHttp
    {



        private static TResultado? obterClasse<TResultado>(string conteudoJson)
        => JsonSerializer.Deserialize<TResultado>(conteudoJson);

        public static AsyncPolicyWrap<HttpResponseMessage> NovasTentativacomTimeoutAsync(int quantidadeTentativas = 3, int tempoLimiteSegundos = 4)
        {


            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(tempoLimiteSegundos, Polly.Timeout.TimeoutStrategy.Pessimistic);
            var politicaRetry = Policy.HandleResult<HttpResponseMessage>((message) =>
                    {
                        var statuscode = (int)message.StatusCode;
                        Console.WriteLine($"Saida : {statuscode}");
                        //Tratamento simplista dos cenários mais comuns para novas tentativas
                        if (statuscode >= 500 && statuscode <= 600)
                            return true;

                        return false;
                    }
            ).WaitAndRetryAsync(quantidadeTentativas, (value) =>
            {
                return TimeSpan.FromSeconds(value);
            });


            return politicaRetry.WrapAsync(timeout);

        }

    }
}
