using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.application.Dto.Request
{
    public class TransferenciaRequest
    {
        public Guid IdCliente { get; set; }
        public decimal Valor { get; set; }
        public InformacaoContaRequest Conta { get; set; }
    }
}
