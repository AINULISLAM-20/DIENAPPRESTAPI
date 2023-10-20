using Microsoft.EntityFrameworkCore;

namespace DIENAPPRESTAPI.Contexts
{
    public class ProviderContext : DbContext
    {
        public ProviderContext(DbContextOptions<Contexts.ProviderContext> options) : base(options)
        {
        }

        public DbSet<Models.ProviderModel> ProviderItem { get; set; } = null!;
    }
}
