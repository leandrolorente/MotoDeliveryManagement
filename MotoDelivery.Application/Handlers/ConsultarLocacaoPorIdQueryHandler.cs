using MediatR;
using MotoDelivery.Application.DTOs;
using MotoDelivery.Application.Interfaces;
using MotoDelivery.Application.Queries.LocacaoQueries;
using System.Threading;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Handlers
{
    public class ConsultarLocacaoPorIdQueryHandler : IRequestHandler<ConsultarLocacaoPorIdQuery, LocacaoDTO>
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public ConsultarLocacaoPorIdQueryHandler(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task<LocacaoDTO> Handle(ConsultarLocacaoPorIdQuery request, CancellationToken cancellationToken)
        {
            var locacao = await _locacaoRepository.GetByIdAsync(request.LocacaoId);

            if (locacao == null)
            {
                return null; // Pode ser tratado com uma exceção ou retorno nulo
            }

            // Mapeando a entidade Locacao para LocacaoDTO
            return new LocacaoDTO(
                identificador: locacao.Id.ToString(), // Convertendo long para string
                entregadorId: locacao.EntregadorId.ToString(), // Convertendo long para string
                motoId: locacao.MotoId.ToString(), // Convertendo long para string
                dataInicio: locacao.DataInicio,
                dataTermino: locacao.DataTermino, // Caso nulo, retorna valor padrão
                dataPrevisaoTermino: locacao.DataPrevisaoTermino,
                plano: locacao.Plano
            );
        }
    }
}