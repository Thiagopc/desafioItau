using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace desafioItau.application.Dto.Response
{
    public class ContaResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("saldo")]
        public decimal Saldo { get; set; }
        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }
        [JsonPropertyName("limiteDiario")]
        public decimal LimiteDiario { get; set; }
    }
}
