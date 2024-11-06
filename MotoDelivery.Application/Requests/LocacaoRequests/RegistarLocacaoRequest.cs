using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Requests.LocacaoRequests
{
    public class RegistrarLocacaoRequest
    {
        [JsonPropertyName("entregador_id")]
        public long EntregadorId { get; set; }

        [JsonPropertyName("moto_id")]
        public long MotoId { get; set; }

        [JsonPropertyName("data_inicio")]
        public DateTime DataInicio { get; set; }

        [JsonPropertyName("data_termino")]
        public DateTime DataTermino { get; set; }

        [JsonPropertyName("data_previsao_termino")]
        public DateTime DataPrevisaoTermino { get; set; }

        [JsonPropertyName("plano")]
        public int Plano { get; set; }
    }
}
