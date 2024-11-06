using Microsoft.EntityFrameworkCore;
using MotoDelivery.Application.Interfaces;
using MotoDelivery.Domain.Entities;
using MotoDelivery.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoDelivery.Infrastructure.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly ApplicationDbContext _context;

        public MotoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Moto> GetByIdAsync(long id)
        {
            return await _context.Motos.FindAsync(id);
        }

        public async Task<Moto> GetByPlacaAsync(string placa)
        {
            // Retorna a primeira moto que corresponde à placa.
            return await _context.Motos.FirstOrDefaultAsync(m => m.Placa == placa);
        }

        public async Task AddAsync(Moto moto)
        {
            await _context.Motos.AddAsync(moto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Moto moto)
        {
            _context.Motos.Update(moto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Moto moto)
        {
            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Moto>> GetAllAsync()
        {
            return await _context.Motos.ToListAsync();
        }
    }
}