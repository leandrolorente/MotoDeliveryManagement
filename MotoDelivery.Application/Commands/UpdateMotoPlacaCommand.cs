using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Commands
{
    public class UpdateMotoPlacaCommand : IRequest
    {
        public Guid MotoId { get; set; }
        public string NovaPlaca { get; set; }
    }
}
