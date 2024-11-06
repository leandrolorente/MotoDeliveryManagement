using MediatR;
using System;

namespace MotoDelivery.Application.Commands
{
    /// <summary>
    /// Comando para informar a devolução de uma locação.
    /// </summary>
    public class InformarDevolucaoCommand : IRequest<bool>
    {
        public long LocacaoId { get; private set; }
        public DateTime DataDevolucao { get; private set; }

        /// <summary>
        /// Construtor do comando para informar a devolução.
        /// </summary>
        /// <param name="locacaoId">Identificador da locação</param>
        /// <param name="dataDevolucao">Data da devolução</param>
        public InformarDevolucaoCommand(long locacaoId, DateTime dataDevolucao)
        {
            LocacaoId = locacaoId;
            DataDevolucao = dataDevolucao;
        }
    }
}