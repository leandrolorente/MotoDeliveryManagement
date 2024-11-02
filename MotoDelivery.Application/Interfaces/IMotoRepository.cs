using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Interfaces
{
    public interface IMotoRepository
    {
        Task<Moto> GetByIdAsync(Guid id);
        Task AddAsync(Moto moto);
        Task UpdateAsync(Moto moto);
        Task DeleteAsync(Moto moto);
        Task<List<Moto>> GetAllAsync();
        Task<List<Moto>> GetByPlacaAsync(string placa);
    }
}
