using desafioItau.domain.Interfaces.Repositories;
using desafioItau.infra.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.infra.Repositories.ClasseBase
{
    public class DbBaseRepository<TEntidade> : IRepositoryDbBase<TEntidade>  where TEntidade : class
    {
        private readonly DbConnection _conexao;
        public DbBaseRepository(DbConnection conexao) => _conexao = conexao;

        public async Task<TEntidade?> Obter(params object[] values)
        => await this._conexao.Set<TEntidade>().FindAsync(values);

        public void Adicionar(TEntidade entidade)
        => this._conexao.Add(entidade);

        public async Task Salvar()        
        => await this._conexao.SaveChangesAsync();
        
        
    }
}
