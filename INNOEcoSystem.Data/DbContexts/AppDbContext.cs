using INNOEcoSystem.Domain.Entities.Applications;
using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Domain.Entities.Assets;
using Microsoft.EntityFrameworkCore;
using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Domain.Entities.Locations;

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
