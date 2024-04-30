using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Interfaces.Evento
{
    public interface IEnvioSQS
    {
        void Publicar<TEntidade>(TEntidade valor);
    }
}
