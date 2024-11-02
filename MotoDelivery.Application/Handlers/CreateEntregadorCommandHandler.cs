using MediatR;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Interfaces;
using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Handlers
{
        public class CreateEntregadorCommandHandler : IRequestHandler<CreateEntregadorCommand, Guid>
        {
            private readonly IEntregadorRepository _entregadorRepository;

            public CreateEntregadorCommandHandler(IEntregadorRepository entregadorRepository)
            {
                _entregadorRepository = entregadorRepository;
            }

            public async Task<Guid> Handle(CreateEntregadorCommand request, CancellationToken cancellationToken)
            {
                // Validate unique CNPJ and CNH
                var existingCnpj = await _entregadorRepository.GetByCnpjAsync(request.Cnpj);
                if (existingCnpj != null)
                {
                    throw new ArgumentException("CNPJ already exists.");
                }

                var existingCnh = await _entregadorRepository.GetByCnhAsync(request.NumeroCnh);
                if (existingCnh != null)
                {
                    throw new ArgumentException("CNH number already exists.");
                }

                var entregador = new Entregador(request.Identificador, request.Nome, request.Cnpj, request.DataNascimento, request.NumeroCnh, request.TipoCnh);
                await _entregadorRepository.AddAsync(entregador);

                return entregador.Id;
            }
        }
    
}
