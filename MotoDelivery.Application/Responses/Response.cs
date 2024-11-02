using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Responses
{
    public class Response
    {

        public Response(bool v1, string v2)
        {
            this.Sucesso = v1;
            this.Mensagem = v2;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}
