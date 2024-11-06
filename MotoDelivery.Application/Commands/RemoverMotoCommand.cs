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
        public long Id { get; private set; }

        public RemoverMotoCommand(long id)
        {
            Id = id;
        }
    }
}
