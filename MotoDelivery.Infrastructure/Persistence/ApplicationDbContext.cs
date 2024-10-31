using Microsoft.EntityFrameworkCore;
using MotoDelivery.Domain.Entities.MotoDelivery.Domain.Entities;
using MotoDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoDelivery.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Entregador> Entregadores { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais (constrangimentos, índices, etc.)
            modelBuilder.Entity<Moto>()
                .HasIndex(m => m.Placa)
                .IsUnique(); // A placa deve ser única

            modelBuilder.Entity<Entregador>()
                .HasIndex(e => e.Cnpj)
                .IsUnique(); // O CNPJ deve ser único

            modelBuilder.Entity<Entregador>()
                .HasIndex(e => e.NumeroCnh)
                .IsUnique(); // O número da CNH deve ser único
        }
    }
}
