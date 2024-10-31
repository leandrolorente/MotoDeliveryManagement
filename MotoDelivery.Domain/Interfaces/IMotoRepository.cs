using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Infrastructure.Interfaces
{
    public interface IMotoRepository
    {
        Task<Moto> GetByIdAsync(Guid id);
        Task<Moto> GetByPlacaAsync(string placa);
        Task AddAsync(Moto moto);
        Task UpdateAsync(Moto moto);
        Task DeleteAsync(Moto moto);
        Task<IEnumerable<Moto>> GetAllAsync();
    }
}
