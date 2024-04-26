using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Entities
{
    public class Historico
    {

        public int Id { get; set; }
        public int IdHistoricoOperacao { get; set; }
        public string Operacao { get; set; }
        public int IdStatus { get; set; }
        public TimeSpan DataHora { get; set; }


    }
}
