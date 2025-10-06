using Microsoft.EntityFrameworkCore;
using PancheriaJP.Models.Categoria;
using PancheriaJP.Models.Ingrediente;
using PancheriaJP.Models.Pancho;

namespace PancheriaJP.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
       
        public DbSet<Pancho> Panchos { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
