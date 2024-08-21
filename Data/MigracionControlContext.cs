using Microsoft.EntityFrameworkCore;
using MigracionControl.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MigracionControl.Data
{
    public class MigracionControlContext : DbContext
    {
        public DbSet<Viajero> Viajeros { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Salida> Salidas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=your_server;Database=MigracionControlDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Viajero>()
                .HasIndex(v => v.Pasaporte)
                .IsUnique();
        }
    }
}
