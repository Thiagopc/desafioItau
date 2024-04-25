using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Entities
{
    public class Outbox
    {
        public string Operacao{ get; set; }
        public int Status { get; set; }
        public Guid IdOperacao { get; set; }
        public DateTime DataHora { get; set; }

    }
}
