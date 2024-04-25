using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Entities
{
    public class HistoricoTransferencia
    {
        public Guid IdTransferencia { get; set; }
        public int IdHistoricoOperacoes { get; set; }
        public DateTime DataHora { get; set; }
    }
}
