using MediatR;
using MotoDelivery.Application.Commands;
using MotoDelivery.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Handlers
{

        public class UpdateMotoPlacaCommandHandler : IRequestHandler<UpdateMotoPlacaCommand>
        {
            private readonly IMotoRepository _motoRepository;

            public UpdateMotoPlacaCommandHandler(IMotoRepository motoRepository)
            {
                _motoRepository = motoRepository;
            }

            public async Task<Unit> Handle(UpdateMotoPlacaCommand request, CancellationToken cancellationToken)
            {
                var moto = await _motoRepository.GetByIdAsync(request.MotoId);
                if (moto == null)
                {
                    throw new ArgumentException("Moto not found.");
                }

                // Update placa
                moto.UpdatePlaca(request.NovaPlaca);
                await _motoRepository.UpdateAsync(moto);

                return Unit.Value;
            }

        Task IRequestHandler<UpdateMotoPlacaCommand>.Handle(UpdateMotoPlacaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    
}
