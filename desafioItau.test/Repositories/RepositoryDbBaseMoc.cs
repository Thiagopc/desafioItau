using desafioItau.domain.Entities;
using desafioItau.domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.test.Repositories
{
    internal class RepositoryDbBaseMoc : IRepositoryDbBase<Historico>
    {
        private List<Historico> _historico;
        public RepositoryDbBaseMoc() {
            _historico = new List<Historico>();        
        
        }


        public void Adicionar(Historico entidade) =>        
            this._historico.Add(entidade);
        

        public Task<Historico?> ObterAsync(params object[] values)
        {
            return null;
        }
        
         
        

        public Task SalvarAsync() =>        
             Task.CompletedTask;
        
    }
}
