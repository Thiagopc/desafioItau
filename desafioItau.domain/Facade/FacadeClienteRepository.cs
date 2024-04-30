using desafioItau.application.Dto.Response;
using desafioItau.domain.Interfaces.Facade;
using desafioItau.domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Facade
{
    public class FacadeClienteRepository : IFacadeClienteRepository
    {
        private readonly IHttpRepository _clientehttp;
        private readonly ICacheRepository _cache;
        public FacadeClienteRepository(IHttpRepository clienteHttp, ICacheRepository cache)
        {
            _clientehttp = clienteHttp;
            _cache = cache;

        }

        //Vou utilizar a url mesmo apenas para facilitação, em um cenário real seria utilizado apenas o id
        public async Task<ClienteResponse?> Obter(string url, CancellationToken token = default)
        {
            ClienteResponse clienteCache = null;

            try
            {
                clienteCache = await this._cache.ObterValor<ClienteResponse>(url);
            }
            catch (Exception ex)
            {
                //   log 
            }


            if (clienteCache != null)
                return clienteCache;

            var cliente = await this._clientehttp.ObterAsync<ClienteResponse>(url);
            validar(cliente);

            await salvarCache(url, cliente);
            return cliente;
        }


        private async Task salvarCache(string chave, ClienteResponse cliente)
        => await this._cache.DefinirValor(chave, cliente);

        private void validar(ClienteResponse? cliente)
        {
            if (string.IsNullOrEmpty(cliente?.Id.ToString()))
                throw new Exception("Cliente inválido");
        }

    }
}
