using MediatR;
using MotoDelivery.Application.Requests.EntregadorRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Commands
{
    public class CreateEntregadorCommand : IRequest<Guid>
    {
        public string Identificador { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroCnh { get; set; }
        public string TipoCnh { get; set; }

        public CreateEntregadorCommand(CadastrarEntregadorRequest request)
        {
            Identificador = Guid.NewGuid().ToString();  // Gera um novo identificador
            Nome = request.Nome;
            Cnpj = request.CNPJ;
            DataNascimento = request.DataNascimento;
            NumeroCnh = request.NumeroCNH;
            TipoCnh = request.TipoCNH;
        }
    }
}
