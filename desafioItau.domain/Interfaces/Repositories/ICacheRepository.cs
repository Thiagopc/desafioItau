using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Interfaces.Repositories
{
    public interface ICacheRepository
    {
        public Task DefinirValor<TEntidade>(string id, TEntidade valor);
        Task<TEntidade?> ObterValor<TEntidade>(string id);
    }
}
