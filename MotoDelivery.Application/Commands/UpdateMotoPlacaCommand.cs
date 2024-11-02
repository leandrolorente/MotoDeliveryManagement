using MediatR;
using MotoDelivery.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Commands
{
    public class UpdateMotoPlacaCommand : IRequest<Response>
    {
        public UpdateMotoPlacaCommand(Guid id, string placa)
        {
            MotoId = id;
            Placa = placa;
        }

        public Guid MotoId { get; set; }
        public string NovaPlaca { get; set; }
        public string Id { get; }
        public string Placa { get; }
    }
}
