using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Requests.EntregadorRequests
{
    public class CadastrarEntregadorRequest
    {
        [Required]
        [JsonPropertyName("identificador")]
        public string Identificador { get; set; }
        [Required]
        [JsonPropertyName("nome")]
        public string Nome { get; set; } 
        [Required]
        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; }
        [Required]
        [JsonPropertyName("data_nascimento")]
        public DateTime DataNascimento { get; set; }
        [Required]
        [JsonPropertyName("numero_cnh")]
        public string NumeroCNH { get; set; }
        [Required]
        [JsonPropertyName("tipo_cnh")]
        public string TipoCNH { get; set; }
        [JsonPropertyName("imagem_cnh")]
        public string ImagemCNH { get; set; }
    }
}
