using desafioItau.application.Dto.Response;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.domain.Interfaces.Services;


namespace desafioItau.domain.Services
{
    public class ClienteService : BaseService, IClienteService
    {

        public ClienteService(IHttpRepository clientehttp)
            : base(clientehttp) { }



        public async Task<ClienteResponse?> Obter(string url, CancellationToken token = default)
        {
            var cliente = await this._clientehttp.ObterAsync<ClienteResponse>(url, token);
            validar(cliente);
            return cliente;

        }

        private void validar(ClienteResponse? cliente)
        {
            if (string.IsNullOrEmpty(cliente?.Id.ToString()))
                throw new Exception("Cliente inválido");
        }


    }
}
