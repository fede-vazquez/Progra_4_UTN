using Microsoft.EntityFrameworkCore;
using PancheriaJP.Models.Pancho;

namespace PancheriaJP.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Pancho> Panchos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pancho>().HasData(
                new Pancho() { Id = 1, Nombre = "Normal", IsVegano = false, Precio = 12.50, Aderezos = new() { "Mayonesa", "Mostaza" } },
                new Pancho() { Id = 2, Nombre = "Super Pancho", IsVegano = false, Precio = 20, Aderezos = new() { "Mayonesa", "Mostaza", "Papitas" } }
            );
        }
    }
}
