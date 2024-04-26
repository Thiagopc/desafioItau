using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Interfaces.Repositories
{
    public interface IRepositoryDbBase<TEntidade>
    {
        public Task<TEntidade?> Obter(params object[] values);

        public void Adicionar(TEntidade entidade);

        public Task Salvar();

    }
}
