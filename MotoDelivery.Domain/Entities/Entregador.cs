using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Domain.Entities
{
    public class Entregador
    {
        public long Id { get; private set; } // Alterado de long para long
        public string Identificador { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string NumeroCnh { get; private set; }
        public string TipoCnh { get; private set; }

        public Entregador(string identificador, string nome, string cnpj, DateTime dataNascimento, string numeroCnh, string tipoCnh)
        {
            // Id será gerado pelo banco, então não precisa ser atribuído aqui
            Identificador = identificador;
            Nome = nome;
            Cnpj = cnpj;
            DataNascimento = dataNascimento;
            NumeroCnh = numeroCnh;
            TipoCnh = tipoCnh;
        }

        public void UpdateCnhImage(string imageUrl)
        {
            // Lógica para atualizar a URL da imagem da CNH
        }
    }
}
