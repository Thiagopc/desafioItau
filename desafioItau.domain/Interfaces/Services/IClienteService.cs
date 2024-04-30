using desafioItau.application.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<ClienteResponse?> Obter( string url);
    }
}
