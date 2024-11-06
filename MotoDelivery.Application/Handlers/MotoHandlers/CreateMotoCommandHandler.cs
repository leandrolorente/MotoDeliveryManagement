using MediatR;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Interfaces;
using MotoDelivery.Application.Responses;
using MotoDelivery.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Handlers.MotoHandlers
{

    public class CreateMotoCommandHandler : IRequestHandler<CreateMotoCommand, long>
    {
        private readonly IMotoRepository _motoRepository;
        private readonly IMessageBus _messageBus;

        public CreateMotoCommandHandler(IMotoRepository motoRepository, IMessageBus messageBus)
        {
            _motoRepository = motoRepository;
            _messageBus = messageBus;
        }

        public async Task<long> Handle(CreateMotoCommand request, CancellationToken cancellationToken)
        {
            // Validate unique placa
            var existingMoto = await _motoRepository.GetByPlacaAsync(request.Placa);
            if (existingMoto != null)
            {
                throw new ArgumentException("Placa already exists.");
            }

            var moto = new Moto(request.Identificador, request.Ano, request.Modelo, request.Placa);
            await _motoRepository.AddAsync(moto);

            // Publish MotoCreated event via message bus
            _messageBus.Publish("MotoCreated", moto);

            return moto.Id;
        }

       
    }

}
