using MediatR;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Interfaces;
using MotoDelivery.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Handlers.MotoHandlers
{

    public class UpdateMotoPlacaCommandHandler : IRequestHandler<UpdateMotoPlacaCommand, Response>
    {
        private readonly IMotoRepository _motoRepository;

        public UpdateMotoPlacaCommandHandler(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }

        public async Task<Response> Handle(UpdateMotoPlacaCommand request, CancellationToken cancellationToken)
        {
            // Busca a moto por ID no repositório
            var moto = await _motoRepository.GetByIdAsync(request.MotoId);

            if (moto == null)
            {
                return new Response(false, "Moto não encontrada.");
            }

            // Atualiza a placa da moto
            moto.UpdatePlaca(request.Placa);

            // Persistir a operação no repositório
            await _motoRepository.UpdateAsync(moto);

            // Retorna uma resposta de sucesso
            return new Response(true, "Placa atualizada com sucesso.");
        }


    }

}
