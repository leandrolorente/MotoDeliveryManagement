using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Interfaces
{
    public interface IEntregadorRepository
    {
        Task<Entregador> GetByIdAsync(Guid id);
        Task<List<Entregador>> GetAllAsync();
        Task AddAsync(Entregador entregador);
        Task UpdateAsync(Entregador entregador);
        Task DeleteAsync(Guid id);
        // Retorna um Entregador ou null se não for encontrado
        Task<Entregador?> GetByCnpjAsync(string cnpj);

        // Retorna um Entregador ou null se não for encontrado
        Task<Entregador?> GetByCnhAsync(string numeroCnh);
    }
}
