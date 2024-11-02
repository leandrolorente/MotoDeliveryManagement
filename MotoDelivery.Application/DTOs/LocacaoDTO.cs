using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.DTOs
{
    public class LocacaoDTO
    {
        public string Identificador { get; private set; }
        public string EntregadorId { get; private set; }
        public string MotoId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataTermino { get; private set; }
        public DateTime DataPrevisaoTermino { get; private set; }
        public int Plano { get; private set; }

        public LocacaoDTO(string identificador, string entregadorId, string motoId, DateTime dataInicio, DateTime dataTermino, DateTime dataPrevisaoTermino, int plano)
        {
            Identificador = identificador;
            EntregadorId = entregadorId;
            MotoId = motoId;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            DataPrevisaoTermino = dataPrevisaoTermino;
            Plano = plano;
        }
    }
}
