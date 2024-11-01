using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.ValueObjects
{
    public class EntregadorDTO
    {
        public string Identificador { get; private set; }
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string NumeroCNH { get; private set; }
        public string TipoCNH { get; private set; }
        public string ImagemCNH { get; private set; }

        public EntregadorDTO(string identificador, string nome, string cnpj, DateTime dataNascimento, string numeroCNH, string tipoCNH, string imagemCNH)
        {
            Identificador = identificador;
            Nome = nome;
            CNPJ = cnpj;
            DataNascimento = dataNascimento;
            NumeroCNH = numeroCNH;
            TipoCNH = tipoCNH;
            ImagemCNH = imagemCNH;
        }
    }
}
