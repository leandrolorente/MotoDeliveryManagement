using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Interfaces
{
    public interface IMotoRepository
    {
        Task<Moto> GetByIdAsync(long id);
        Task AddAsync(Moto moto);
        Task UpdateAsync(Moto moto);
        Task DeleteAsync(Moto moto);
        Task<List<Moto>> GetAllAsync();

        // Mantemos o retorno de uma única Moto, pois placa deve ser única.
        Task<Moto> GetByPlacaAsync(string placa);
    }
}