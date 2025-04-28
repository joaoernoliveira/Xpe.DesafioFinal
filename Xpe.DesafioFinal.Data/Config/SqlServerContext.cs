
using Arquitetura.Teste.EntityDDD.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Xpe.DesafioFinal.Data.Config
{
    public class SqlServerContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public SqlServerContext(DbContextOptions<SqlServerContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteMap).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2CU4HVV\\SQLEXPRESS;Database=DesafioFinalDb;User Id=sa;Password=mqpoqtj;TrustServerCertificate=true");
        }

    }
}
