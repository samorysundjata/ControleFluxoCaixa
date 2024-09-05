using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ControleFluxoCaixa.Infraestrutura.Contexto
{
    public class ControleFluxoCaixaDbContextFactory : IDesignTimeDbContextFactory<ControleFluxoCaixaDbContext>
    {
        public ControleFluxoCaixaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ControleFluxoCaixaDbContext>();

            var currentDirectory = Directory.GetCurrentDirectory();
            var appSettingsPath = Path.Combine(currentDirectory, "appsettings.json");


            IConfigurationRoot configuration = new ConfigurationBuilder()
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(connectionString);

            return new ControleFluxoCaixaDbContext(optionsBuilder.Options);
        }
    }
}