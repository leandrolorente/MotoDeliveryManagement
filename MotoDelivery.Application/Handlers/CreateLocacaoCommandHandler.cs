using MediatR;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Interfaces;
using MotoDelivery.Domain.Entities.MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Handlers
{
    public class CreateLocacaoCommandHandler : IRequestHandler<CreateLocacaoCommand, Guid>
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IEntregadorRepository _entregadorRepository;

        public CreateLocacaoCommandHandler(ILocacaoRepository locacaoRepository, IEntregadorRepository entregadorRepository)
        {
            _locacaoRepository = locacaoRepository;
            _entregadorRepository = entregadorRepository;
        }

        public async Task<Guid> Handle(CreateLocacaoCommand request, CancellationToken cancellationToken)
        {
            // Validate Entregador is in category A
            var entregador = await _entregadorRepository.GetByIdAsync(Guid.Parse(request.EntregadorId));
            if (entregador == null || entregador.TipoCnh != "A")
            {
                throw new ArgumentException("Entregador is not authorized to rent a moto.");
            }

            var locacao = new Locacao(Guid.Parse(request.EntregadorId), Guid.Parse(request.MotoId), request.DataInicio, request.DataTermino, request.DataPrevisaoTermino, request.Plano);
            await _locacaoRepository.AddAsync(locacao);

            return locacao.Id;
        }
    }
}
