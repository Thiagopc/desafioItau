using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.domain.Entities
{
    public class HistoricoOperacao
    {
        public int Id { get; set; }
        public string idOrigem { get; set; }
        public string IdDestino { get; set; }
        public decimal Valor { get; set; }
        public string IdCliente { get; set; }
        public int IdStatus { get; set; }
        public DateTime DataHora { get; set; }
    }
}
