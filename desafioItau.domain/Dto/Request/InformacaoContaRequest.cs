using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioItau.application.Dto.Request
{
    public class InformacaoContaRequest
    {
        public Guid IdOrigem { get; set; }
        public Guid IdDestino { get; set; }
    }
}
