using MediatR;
using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Queries.MotoQueries
{
    public class ConsultarMotosQuery : IRequest<List<Moto>>
    {
        public string Placa { get; }

        public ConsultarMotosQuery(string placa)
        {
            Placa = placa;
        }
    }
}
