using InfoBovinosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoBovinosAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }

        public DbSet<Animal> Animales { get; set; }
        public DbSet<Raza> Razas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasOne(a => a.Raza)
                .WithMany(r => r.Animales)
                .HasForeignKey(a => a.RazaId)
                .IsRequired();

            });

            modelBuilder.Entity<Animal>()
                .Property(a => a.FechaNacimiento)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Animal>()
                .Property(a => a.Precio)
                .HasColumnType("REAL");
        }
    }
}
