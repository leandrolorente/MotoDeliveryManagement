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
        public Guid Id { get; private set; }

        public RemoverMotoCommand(Guid id)
        {
            Id = id;
        }
    }
}
