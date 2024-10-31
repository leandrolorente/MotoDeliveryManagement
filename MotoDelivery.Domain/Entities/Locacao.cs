using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.Entities
{
    namespace MotoDelivery.Domain.Entities
    {
        public class Locacao
        {
            public Guid Id { get; private set; }
            public Guid EntregadorId { get; private set; }
            public Guid MotoId { get; private set; }
            public DateTime DataInicio { get; private set; }
            public DateTime DataTermino { get; private set; }
            public DateTime DataPrevisaoTermino { get; private set; }
            public DateTime? DataDevolucao { get; private set; }
            public int Plano { get; private set; }

            public Locacao(Guid entregadorId, Guid motoId, DateTime dataInicio, DateTime dataTermino, DateTime dataPrevisaoTermino, int plano)
            {
                Id = Guid.NewGuid();
                EntregadorId = entregadorId;
                MotoId = motoId;
                DataInicio = dataInicio;
                DataTermino = dataTermino;
                DataPrevisaoTermino = dataPrevisaoTermino;
                Plano = plano;
            }

            public void SetDataDevolucao(DateTime dataDevolucao)
            {
                DataDevolucao = dataDevolucao;
            }

            public decimal CalcularValorTotal()
            {
                // Logic for calculating total rental value
                return 0; // Placeholder
            }
        }
    }
}
