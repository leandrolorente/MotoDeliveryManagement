using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MotoDelivery.Application.Commands
{
    public class CreateMotoCommand : IRequest<Guid>
    {
        public string Identificador { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
    }
}
