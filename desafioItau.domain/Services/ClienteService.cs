using desafioItau.application.Dto.Response;
using desafioItau.domain.Entities;
using desafioItau.domain.Interfaces.Facade;
using desafioItau.domain.Interfaces.Repositories;
using desafioItau.domain.Interfaces.Services;


namespace desafioItau.domain.Services
{
    public class ClienteService :  IClienteService
    {       

        private readonly IFacadeClienteRepository _facaderepo;
        public ClienteService(IFacadeClienteRepository facaderepo)
        {
            _facaderepo = facaderepo;
        }



        public async Task<ClienteResponse?> Obter(string url)
            => await this._facaderepo.Obter(url);

    }




}

