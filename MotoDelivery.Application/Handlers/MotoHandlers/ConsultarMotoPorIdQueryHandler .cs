using MediatR;
using MotoDelivery.Application.Interfaces;
using MotoDelivery.Application.Queries.MotoQueries;
using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Handlers.MotoHandlers
{
    public class ConsultarMotoPorIdQueryHandler : IRequestHandler<ConsultarMotoPorIdQuery, Moto>
    {
        private readonly IMotoRepository _motoRepository;

        public ConsultarMotoPorIdQueryHandler(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }

        public async Task<Moto> Handle(ConsultarMotoPorIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null) return null;
            return await _motoRepository.GetByIdAsync(request.Id);
        }
    }
}
