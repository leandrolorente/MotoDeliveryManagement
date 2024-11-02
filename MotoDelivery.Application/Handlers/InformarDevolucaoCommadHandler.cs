using MediatR;
using MotoDelivery.Application.Commands;
using MotoDelivery.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Handlers
{
    /// <summary>
    /// Handler responsável por processar o comando de devolução.
    /// </summary>
    public class InformarDevolucaoCommandHandler : IRequestHandler<InformarDevolucaoCommand, bool>
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public InformarDevolucaoCommandHandler(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        /// <summary>
        /// Manipula o comando de devolução.
        /// </summary>
        /// <param name="request">Comando de devolução</param>
        /// <param name="cancellationToken">Token de cancelamento</param>
        /// <returns>Resultado da operação (sucesso ou falha)</returns>
        public async Task<bool> Handle(InformarDevolucaoCommand request, CancellationToken cancellationToken)
        {
            var locacao = await _locacaoRepository.GetByIdAsync(request.LocacaoId);

            if (locacao == null)
            {
                throw new KeyNotFoundException("Locação não encontrada.");
            }

            locacao.SetDataDevolucao(request.DataDevolucao);

            await _locacaoRepository.UpdateAsync(locacao);

            return true;
        }
    }
}