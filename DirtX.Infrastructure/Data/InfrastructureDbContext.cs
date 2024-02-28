using Microsoft.EntityFrameworkCore;

namespace DirtX.Infrastructure.Data
{
    public class InfrastructureDbContext : DbContext
    {
        public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options) : base(options) {}
    }
}
