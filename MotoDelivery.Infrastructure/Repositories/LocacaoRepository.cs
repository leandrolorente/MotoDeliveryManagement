using Microsoft.EntityFrameworkCore;
using MotoDelivery.Application.Interfaces;
using MotoDelivery.Domain.Entities.MotoDelivery.Domain.Entities;
using MotoDelivery.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Infrastructure.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public LocacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Locacao> GetByIdAsync(long id)
        {
            return await _context.Locacoes.FindAsync(id);
        }

        public async Task<List<Locacao>> GetAllAsync()
        {
            return await _context.Locacoes.ToListAsync();
        }

        public async Task AddAsync(Locacao locacao)
        {
            await _context.Locacoes.AddAsync(locacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Locacao locacao)
        {
            _context.Locacoes.Update(locacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var locacao = await _context.Locacoes.FindAsync(id);
            if (locacao != null)
            {
                _context.Locacoes.Remove(locacao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
