using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Entities
{
    public class Transacao
    {
        public string Id { get; set; }
        public List<Historico> Historicos { get; set; }
        //public virtual HistoricoTransferencia HistoricoTransferencia { get; set; }
    }
}
