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
        public string IdTransacao { get; set; }
        public string Operacao { get; set; }
        public int IdStatus { get; set; }
        public DateTime DataHora { get; set; }

        public Transacao Transacao { get; set; }

    }
}
