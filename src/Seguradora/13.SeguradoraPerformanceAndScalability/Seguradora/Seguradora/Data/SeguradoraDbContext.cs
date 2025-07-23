using Microsoft.EntityFrameworkCore;
using Seguradora.Domain;

namespace Seguradora.Data
{
    public class SeguradoraDbContext : DbContext
    {
        public SeguradoraDbContext(DbContextOptions<SeguradoraDbContext> options) : base(options) { }

        public DbSet<Sinistro> Sinistros => Set<Sinistro>();
    }
}
