using Microsoft.EntityFrameworkCore;
using MigracionControl.Models;
using MigracionControlWebApp3.Models;


namespace MigracionControlWebApp3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Definir DbSets para cada modelo
        public DbSet<Viajero> Viajeros { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Salida> Salidas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}