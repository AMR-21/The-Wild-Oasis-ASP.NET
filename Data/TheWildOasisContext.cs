using Microsoft.EntityFrameworkCore;

namespace TheWildOasis.Data
{
  public class TheWildOasisContext : DbContext
  {
    public TheWildOasisContext(DbContextOptions<TheWildOasisContext> options)
      : base(options)
    {
    }

    // Define your DbSets here. For example:
    // public DbSet<YourEntity> YourEntities { get; set; }
    public DbSet<TheWildOasis.Models.Cabin> Cabins { get; set; }
  }
}