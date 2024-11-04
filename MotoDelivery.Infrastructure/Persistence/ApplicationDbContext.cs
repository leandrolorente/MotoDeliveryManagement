using Microsoft.EntityFrameworkCore;
using MotoDelivery.Domain.Entities;
using MotoDelivery.Domain.Entities.MotoDelivery.Domain.Entities;

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

            // Configuração da Moto
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Identificador).IsRequired();
                entity.Property(m => m.Ano).IsRequired();
                entity.Property(m => m.Modelo).IsRequired();
                entity.Property(m => m.Placa).IsRequired();
                entity.HasIndex(m => m.Placa).IsUnique();

             
            });

            // Configuração do Entregador
            modelBuilder.Entity<Entregador>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Identificador).IsRequired();
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Cnpj).IsRequired();
                entity.Property(e => e.DataNascimento).IsRequired();
                entity.Property(e => e.NumeroCnh).IsRequired();
                entity.Property(e => e.TipoCnh).IsRequired();

                entity.HasIndex(e => e.Cnpj).IsUnique(); // CNPJ único
                entity.HasIndex(e => e.NumeroCnh).IsUnique(); // CNH única
            });

            // Configuração da Locacao
            modelBuilder.Entity<Locacao>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.Property(l => l.DataInicio).IsRequired();
                entity.Property(l => l.DataTermino).IsRequired();
                entity.Property(l => l.DataPrevisaoTermino).IsRequired();
                entity.Property(l => l.Plano).IsRequired();

                entity.HasOne(l => l.Entregador)
                      .WithMany()
                      .HasForeignKey(l => l.EntregadorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.Moto)
                      .WithMany()
                      .HasForeignKey(l => l.MotoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}