using DesafioAssistencia.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioAssistencia.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<GrupoVeiculo> GruposVeiculos { get; set; }
        public DbSet<EmpresaAssistencia> EmpresasAssistencia { get; set; }
        public DbSet<PlanoAssistencia> PlanosAssistencia { get; set; }
        public DbSet<VeiculoAssistencia> VeiculosAssistencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VeiculoAssistencia>()
                .HasKey(va => new { va.VeiculoId, va.PlanoId });
        }
    }
}
