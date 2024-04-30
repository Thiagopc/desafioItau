using desafioItau.application.Dto.Response;
using desafioItau.domain.Entities;
using desafioItau.domain.Interfaces.Facade;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.domain.Interfaces.Services;


namespace desafioItau.domain.Services
{
    public class ClienteService :  IClienteService
    {

        //public ClienteService(IHttpRepository clientehttp, IRepositoryDbBase<Historico> repositorioHistorico)
        //    : base(clientehttp, repositorioHistorico) { }

        private readonly IFacadeClienteRepository _facaderepo;
        public ClienteService(IFacadeClienteRepository facaderepo)
        {
            _facaderepo = facaderepo;
        }



        public async Task<ClienteResponse?> Obter(string url, CancellationToken token = default)
            => await this._facaderepo.Obter(url, token);

    }




}

