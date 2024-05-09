using Microsoft.EntityFrameworkCore;

namespace BD.Models
{
    public class PruebaAlmarContext : DbContext
    {
        public PruebaAlmarContext(DbContextOptions<PruebaAlmarContext> options)
            : base(options)
        {

        }

        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detalle>().ToTable("Detalle");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }

    }
}
