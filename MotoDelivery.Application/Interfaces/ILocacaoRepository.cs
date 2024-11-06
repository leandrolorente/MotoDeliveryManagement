using MotoDelivery.Domain.Entities.MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Application.Interfaces
{
    public interface ILocacaoRepository
    {
        Task<Locacao> GetByIdAsync(long id);
        Task<List<Locacao>> GetAllAsync();
        Task AddAsync(Locacao locacao);
        Task UpdateAsync(Locacao locacao);
        Task DeleteAsync(long id);
    }
}
