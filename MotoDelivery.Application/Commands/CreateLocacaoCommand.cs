using MediatR;
using MotoDelivery.Application.Requests.LocacaoRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Commands
{

    public class CreateLocacaoCommand : IRequest<long>
    {

        public CreateLocacaoCommand(RegistrarLocacaoRequest request)
        {
            EntregadorId = request.EntregadorId;
            MotoId = request.MotoId;
            DataInicio = request.DataInicio;
            DataTermino = request.DataTermino;
            DataPrevisaoTermino = request.DataPrevisaoTermino;
            Plano = request.Plano;
        }

        public long EntregadorId { get; set; }
        public long MotoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public DateTime DataPrevisaoTermino { get; set; }
        public int Plano { get; set; }
    }
    
}
