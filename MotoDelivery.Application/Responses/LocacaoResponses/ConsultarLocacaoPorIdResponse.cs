using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Responses.LocacaoResponses
{
    public class ConsultarLocacaoPorIdResponse
    {
        public string Identificador { get; set; }
        public string EntregadorId { get; set; }
        public string MotoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public DateTime DataPrevisaoTermino { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}
