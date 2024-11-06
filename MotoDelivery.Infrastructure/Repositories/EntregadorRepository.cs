using Microsoft.EntityFrameworkCore;
using MotoDelivery.Application.Interfaces;
using MotoDelivery.Domain.Entities;
using MotoDelivery.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Infrastructure.Repositories
{
    public class EntregadorRepository : IEntregadorRepository
    {
        private readonly ApplicationDbContext _context;

        public EntregadorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Entregador> GetByIdAsync(long id)
        {
            return await _context.Entregadores.FindAsync(id);
        }

        public async Task<List<Entregador>> GetAllAsync()
        {
            return await _context.Entregadores.ToListAsync();
        }

        public async Task AddAsync(Entregador entregador)
        {
            await _context.Entregadores.AddAsync(entregador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entregador entregador)
        {
            _context.Entregadores.Update(entregador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entregador = await _context.Entregadores.FindAsync(id);
            if (entregador != null)
            {
                _context.Entregadores.Remove(entregador);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Entregador?> GetByCnpjAsync(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                throw new ArgumentException("O CNPJ não pode ser nulo ou vazio.", nameof(cnpj));

            return await _context.Entregadores
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(e => e.Cnpj == cnpj);
        }

        public async Task<Entregador?> GetByCnhAsync(string numeroCnh)
        {
            if(string.IsNullOrWhiteSpace(numeroCnh))
                throw new ArgumentException("O número da CNH não pode ser nulo ou vazio.", nameof(numeroCnh));

            return await _context.Entregadores
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(e => e.NumeroCnh == numeroCnh);
        }
    
    }
}
