using Microsoft.EntityFrameworkCore;

namespace DIENAPPRESTAPI.Contexts;

public class SeekerContext : DbContext

{
    public SeekerContext(DbContextOptions<Contexts.SeekerContext> options)
   : base(options)
    {
    }

    public DbSet<Models.SeekerModel> SeekerItem { get; set; } = null!;
}
