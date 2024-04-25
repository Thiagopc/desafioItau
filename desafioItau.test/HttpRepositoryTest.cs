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
            
                var factoryHttp = new BuildHttpFactory().Build("http://localhost:9090/contas/saldos", "", 500);
                var repositorio = new HttpRepository(factoryHttp);
                await repositorio.ObterAsync<object>("http://localhost:9090/contas/saldos");         

        }



        [TestMethod]
        public async Task RetornoBemsucedido()
        {            
            var factoryHttp = new BuildHttpFactory().Build("http://localhost:9090/contas/saldos", JsonSerializer.Serialize(new ContaResponse()), 200);
            var repositorio = new HttpRepository(factoryHttp);
            await repositorio.ObterAsync<ContaResponse>("http://localhost:9090/contas/saldos");
            
        }
    }
}