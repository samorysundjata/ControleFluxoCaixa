// ControleFluxoCaixa.Infraestrutura/Contexto/ControleFluxoCaixaDbContext.cs
using ControleFluxoCaixa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ControleFluxoCaixa.Infraestrutura.Contexto
{
    public class ControleFluxoCaixaDbContext : DbContext
    {
        public ControleFluxoCaixaDbContext(DbContextOptions<ControleFluxoCaixaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=controlefluxocaixa.db");
            }
        }
    }  
}
