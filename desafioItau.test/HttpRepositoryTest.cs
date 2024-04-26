using desafioItau.application.Dto.Response;
using desafioItau.infra.Repositories.ClasseBase;
using desafioItau.test.Build;
using System.Text.Json;

namespace desafioItau.test
{
    [TestClass]
    public class HttpRepositoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task ExcedidoNumeroMaximoFalhasRetry()
        {
            string urlRequisicao = "http://localhost:9090/contas/saldos";


                var factoryHttp =  BuildHttpFactory.Build(urlRequisicao, "", 500);
                var repositorio = new HttpRepository(factoryHttp);
                await repositorio.ObterAsync<object>(urlRequisicao);         

        }



        [TestMethod]
        public async Task RetornoSucesso()
        {            
            var factoryHttp = BuildHttpFactory.Build("http://localhost:9090/contas/saldos", JsonSerializer.Serialize(new ContaResponse()), 200);
            var repositorio = new HttpRepository(factoryHttp);
            await repositorio.ObterAsync<ContaResponse>("http://localhost:9090/contas/saldos");
            
        }
    }
}