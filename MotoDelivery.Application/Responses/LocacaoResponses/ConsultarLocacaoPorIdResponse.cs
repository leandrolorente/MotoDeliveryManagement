using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Responses.LocacaoResponses
{
    public class ConsultarLocacaoPorIdResponse
    {
        [JsonPropertyName("identificador")]
        public string Identificador { get; set; }

        [JsonPropertyName("entregador_id")]
        public string EntregadorId { get; set; }

        [JsonPropertyName("moto_id")]
        public string MotoId { get; set; }

        [JsonPropertyName("data_inicio")]
        public DateTime DataInicio { get; set; }

        [JsonPropertyName("data_termino")]
        public DateTime DataTermino { get; set; }

        [JsonPropertyName("data_previsao_termino")]
        public DateTime DataPrevisaoTermino { get; set; }

        [JsonPropertyName("data_devolucao")]
        public DateTime? DataDevolucao { get; set; }

        [JsonPropertyName("valor_diaria")]
        public decimal ValorDiaria { get; set; }
    }
}
