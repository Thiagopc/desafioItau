using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Entities
{
    public class HistoricoOperacao
    {
        public int Id { get; set; }
        public Guid IdOrigem { get; set; }
        public Guid IdDestino { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}
