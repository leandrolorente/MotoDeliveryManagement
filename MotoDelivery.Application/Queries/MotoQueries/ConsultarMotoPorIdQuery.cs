using MediatR;
using MotoDelivery.Application.DTOs;
using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Queries.MotoQueries
{
    public class ConsultarMotoPorIdQuery : IRequest<Moto>
    {
        public long Id { get; private set; }

        public ConsultarMotoPorIdQuery(long id)
        {
            Id = id;
        }
    }
}
