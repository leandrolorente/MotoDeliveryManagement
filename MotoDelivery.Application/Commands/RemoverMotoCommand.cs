using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Commands
{
    public class RemoverMotoCommand : IRequest<bool>
    {
        public string Id { get; private set; }

        public RemoverMotoCommand(string id)
        {
            Id = id;
        }
    }
}
