using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class FutManagerDbContext : DbContext
    {
        public FutManagerDbContext(DbContextOptions<FutManagerDbContext> options)
            : base(options) { }
    }
}
