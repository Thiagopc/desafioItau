using desafioItau.domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Services
{
    public abstract class BaseService
    {
        protected  readonly IHttpRepository _clientehttp;
        public BaseService(IHttpRepository clientehttp)
        {
            _clientehttp = clientehttp;
        }
    }
}
