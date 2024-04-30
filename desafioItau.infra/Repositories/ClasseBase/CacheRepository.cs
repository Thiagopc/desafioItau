using desafioItau.domain.Interfaces.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace desafioItau.infra.Repositories.ClasseBase
{
    public class CacheRepository : ICacheRepository
    {
        private readonly string _conexao = "redis:6379";
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;
        public CacheRepository()
        {
            _redis = ConnectionMultiplexer.Connect(_conexao);
            _db = _redis.GetDatabase();
        }


        public async Task DefinirValor<TEntidade>(string id, TEntidade valor)
        => await this._db.StringSetAsync(id, serializador(valor));

        public async Task<TEntidade?> ObterValor<TEntidade>(string id)
        {
            var resposta = await this._db.StringGetAsync(id);
            if(resposta.HasValue)
            {
                return desserializar<TEntidade>(resposta);
            }

            return default(TEntidade);
        }


        private TEntidade desserializar<TEntidade>(string valor)
            => JsonSerializer.Deserialize<TEntidade>(valor);


        private string serializador<TEntidade>(TEntidade valor)
        => JsonSerializer.Serialize(valor);



    }
}
