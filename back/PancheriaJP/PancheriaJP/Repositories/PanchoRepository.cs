using PancheriaJP.Config;
using PancheriaJP.Models.Pancho;

namespace PancheriaJP.Repositories
{
    public interface IPanchoRepository : IRepository<Pancho> {}
    
    public class PanchoRepository : Repository<Pancho>, IPanchoRepository
    {
        private readonly ApplicationDbContext _db;

        public PanchoRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
    }
}
