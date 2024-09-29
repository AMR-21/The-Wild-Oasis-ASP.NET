using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TheWildOasis.Data
{
  public class TheWildOasisContext : IdentityDbContext<IdentityUser>
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