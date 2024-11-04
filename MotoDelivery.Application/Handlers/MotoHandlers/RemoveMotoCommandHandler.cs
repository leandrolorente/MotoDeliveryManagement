using MediatR;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Handlers.MotoHandlers
{
    public class RemoverMotoCommandHandler : IRequestHandler<RemoverMotoCommand, bool>
    {
        private readonly IMotoRepository _motoRepository;

        public RemoverMotoCommandHandler(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }

        /// <summary>
        /// Manuseia o comando de remoção de uma moto pelo ID.
        /// </summary>
        /// <param name="request">Comando contendo o ID da moto a ser removida</param>
        /// <param name="cancellationToken">Token de cancelamento</param>
        /// <returns>Retorna 'true' se a moto foi removida com sucesso, caso contrário 'false'</returns>
        public async Task<bool> Handle(RemoverMotoCommand request, CancellationToken cancellationToken)
        {
            var moto = await _motoRepository.GetByIdAsync(request.Id);

            if (moto == null)
            {
                // Retorna 'false' se a moto não foi encontrada
                return false;
            }

            // Remove a moto do repositório
            await _motoRepository.DeleteAsync(moto);
            return true;
        }
    }
}
