using MediatR;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Interfaces;
using MotoDelivery.Domain.Entities.MotoDelivery.Domain.Entities;
using MotoDelivery.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Handlers
{
    public class CreateLocacaoCommandHandler : IRequestHandler<CreateLocacaoCommand, long>
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IEntregadorRepository _entregadorRepository;

        public CreateLocacaoCommandHandler(ILocacaoRepository locacaoRepository, IEntregadorRepository entregadorRepository)
        {
            _locacaoRepository = locacaoRepository;
            _entregadorRepository = entregadorRepository;
        }

        public async Task<long> Handle(CreateLocacaoCommand request, CancellationToken cancellationToken)
        {
            // Validar se o entregador tem CNH de categoria A ou AB
            var entregador = await _entregadorRepository.GetByIdAsync(request.EntregadorId);
            if (entregador == null || (entregador.TipoCnh != "A" && entregador.TipoCnh != "AB"))
            {
                throw new ArgumentException("Entregador não está autorizado a alugar uma moto.");
            }

            // Validar se o plano é válido (7, 15, 30, 45, ou 50)
            if (request.Plano != 7 && request.Plano != 15 && request.Plano != 30 && request.Plano != 45 && request.Plano != 50)
            {
                throw new ArgumentException("Plano inválido. Escolha um plano de 7, 15, 30, 45 ou 50 dias.");
            }

            // Definir a data de início como o primeiro dia após a data de criação
            var dataInicio = DateTime.UtcNow.AddDays(1);

            // Calcular a data de término e a previsão de término com base no plano
            var dataTermino = dataInicio.AddDays(request.Plano);
            var dataPrevisaoTermino = dataTermino; // A previsão de término é a mesma que o término inicialmente

            // Criar a locação
            var locacao = new Locacao(request.EntregadorId, request.MotoId, dataInicio, dataTermino, dataPrevisaoTermino, request.Plano);

            // Salvar a locação no repositório
            await _locacaoRepository.AddAsync(locacao);

            return locacao.Id;
        }
    }
}
