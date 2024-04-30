using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace desafioItau.application.Dto.Response
{
    public class ClienteResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }
        [JsonPropertyName("tipoPessoa")]
        public string TipoPessoa { get; set; }
    }
}
