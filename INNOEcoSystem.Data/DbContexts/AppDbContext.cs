using INNOEcoSystem.Domain.Entities.Applications;
using INNOEcoSystem.Domain.Entities.Assets;
using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Domain.Entities.Locations;
using INNOEcoSystem.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Lacations { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<LocationAsset> LacationAssets { get; set; }
    public DbSet<Category> DepartmentCategories { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.IsDeleted)
            .HasColumnName("IsDeleted");
    }
}
