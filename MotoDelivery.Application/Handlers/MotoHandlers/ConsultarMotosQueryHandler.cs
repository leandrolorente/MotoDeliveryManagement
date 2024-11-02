using MediatR;
using MotoDelivery.Application.Interfaces;
using MotoDelivery.Application.Queries.MotoQueries;
using MotoDelivery.Domain.Entities;


namespace MotoDelivery.Application.Handlers.MotoHandlers
{
    public class ConsultarMotosQueryHandler : IRequestHandler<ConsultarMotosQuery, List<Moto>>
    {
        private readonly IMotoRepository _motoRepository;

        public ConsultarMotosQueryHandler(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }

        public async Task<List<Moto>> Handle(ConsultarMotosQuery request, CancellationToken cancellationToken)
        {
            // Consultar motos filtrando pela placa no repositório
            if (string.IsNullOrEmpty(request.Placa))
            {
                // Se a placa não foi fornecida, retornar todas as motos
                return await _motoRepository.GetAllAsync();
            }

            // Se a placa foi fornecida, retornar as motos que correspondem à placa
            return await _motoRepository.GetByPlacaAsync(request.Placa);
        }
    }
}
