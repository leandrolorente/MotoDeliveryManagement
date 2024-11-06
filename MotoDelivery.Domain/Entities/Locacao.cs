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
            public long Id { get; private set; } // Alterado de long para long
            public long EntregadorId { get; private set; } // Alterado de long para long
            public long MotoId { get; private set; }
            public DateTime DataInicio { get; private set; }
            public DateTime DataTermino { get; private set; }
            public DateTime DataPrevisaoTermino { get; private set; }
            public DateTime? DataDevolucao { get; private set; }
            public int Plano { get; private set; }
            public Entregador Entregador { get; private set; }
            public Moto Moto { get; private set; }
            public Locacao(long entregadorId, long motoId, DateTime dataInicio, DateTime dataTermino, DateTime dataPrevisaoTermino, int plano, long id = 0)
            {
                Id = id;
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
                decimal valorDiaria = Plano switch
                {
                    7 => 30,
                    15 => 28,
                    30 => 22,
                    45 => 20,
                    50 => 18,
                    _ => throw new InvalidOperationException("Plano inválido")
                };

                // Se a data de devolução for anterior à prevista, aplica-se a multa
                if (DataDevolucao.HasValue && DataDevolucao.Value < DataPrevisaoTermino)
                {
                    int diasNaoEfetivados = (DataPrevisaoTermino - DataDevolucao.Value).Days;
                    decimal multa = Plano switch
                    {
                        7 => 0.20m,
                        15 => 0.40m,
                        _ => 0m, // Outros planos não têm multa adicional
                    };

                    return (DataDevolucao.Value - DataInicio).Days * valorDiaria + (diasNaoEfetivados * valorDiaria * multa);
                }

                // Se a data de devolução for posterior à prevista, aplica-se uma multa adicional por dia excedido
                if (DataDevolucao.HasValue && DataDevolucao.Value > DataPrevisaoTermino)
                {
                    int diasExcedidos = (DataDevolucao.Value - DataPrevisaoTermino).Days;
                    return (DataPrevisaoTermino - DataInicio).Days * valorDiaria + (diasExcedidos * 50); // Multa por dia adicional
                }

                // Cálculo normal se a devolução for na data prevista
                return (DataPrevisaoTermino - DataInicio).Days * valorDiaria;
            }
        }
    }
}
