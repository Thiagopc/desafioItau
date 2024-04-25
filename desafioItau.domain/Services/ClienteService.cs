using desafioItau.application.Dto.Response;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.domain.Interfaces.Services;


namespace desafioItau.domain.Services
{
    public class ClienteService : BaseService, IClienteService
    {

        public ClienteService(IHttpRepository clientehttp)
            : base(clientehttp) { }



        public async Task Validar(string url, CancellationToken token = default)
        {
            var cliente = await this._clientehttp.ObterAsync<ClienteResponse>(url, token);
            if (!string.IsNullOrEmpty(cliente?.Id.ToString()))
                return;

            throw new Exception("Cliente inválido");
        }


    }
}
