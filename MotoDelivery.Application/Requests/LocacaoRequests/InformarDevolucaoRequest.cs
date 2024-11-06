using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Requests.LocacaoRequests
{
    public class InformarDevolucaoRequest
    {
        [JsonPropertyName("data_devolucao")]
        public DateTime DataDevolucao { get; set; }
    }
}
