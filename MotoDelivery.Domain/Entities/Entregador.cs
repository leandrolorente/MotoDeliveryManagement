using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.Entities
{
    public class Entregador
    {
        public Guid Id { get; private set; }
        public string Identificador { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string NumeroCnh { get; private set; }
        public string TipoCnh { get; private set; }

        public Entregador(string identificador, string nome, string cnpj, DateTime dataNascimento, string numeroCnh, string tipoCnh)
        {
            Id = Guid.NewGuid();
            Identificador = identificador;
            Nome = nome;
            Cnpj = cnpj;
            DataNascimento = dataNascimento;
            NumeroCnh = numeroCnh;
            TipoCnh = tipoCnh;
        }

        public void UpdateCnhImage(string imageUrl)
        {
            // Logic to update CNH image URL
        }
    }
}
