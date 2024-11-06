using MediatR;
using MotoDelivery.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Queries.LocacaoQueries
{
    public class ConsultarLocacaoPorIdQuery : IRequest<LocacaoDTO>
    {
        public long LocacaoId { get; private set; }

        /// <summary>
        /// Construtor da query para buscar locação pelo ID.
        /// </summary>
        /// <param name="locacaoId">Identificador único da locação</param>
        public ConsultarLocacaoPorIdQuery(long locacaoId)
        {
            LocacaoId = locacaoId;
        }
    }
}
