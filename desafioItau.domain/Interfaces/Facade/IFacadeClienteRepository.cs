using desafioItau.application.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Interfaces.Facade
{
    public interface IFacadeClienteRepository
    {
        public Task<ClienteResponse?> Obter(string url, CancellationToken token = default);
    }
}
