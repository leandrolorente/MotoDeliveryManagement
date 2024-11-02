using MediatR;
using MotoDelivery.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Queries.MotoQueries
{
    public class ConsultarMotoPorIdQuery : IRequest<MotoDTO>
    {
        public string Id { get; private set; }

        public ConsultarMotoPorIdQuery(string id)
        {
            Id = id;
        }
    }
}
