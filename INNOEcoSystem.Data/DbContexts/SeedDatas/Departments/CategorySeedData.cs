using INNOEcoSystem.Domain.Entities.Departments;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Data.DbContexts.SeedDatas.Departments;

public class CategorySeedData
{
    public static void CategoryData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasData(
                new Category { Name = "Technology", Image = "technology.jpg" },
                new Category { Name = "Healthcare", Image = "healthcare.png" },
                new Category { Name = "Education", Image = "education.jpg" },
                new Category { Name = "Environment", Image = "environment.png" },
                new Category { Name = "Agriculture", Image = "agriculture.jpg" },
                new Category { Name = "Energy", Image = "energy.png" },
                new Category { Name = "Manufacturing", Image = "manufacturing.jpg" },
                new Category { Name = "Finance", Image = "finance.png" },
                new Category { Name = "Retail", Image = "retail.jpg" },
                new Category { Name = "Transportation", Image = "transportation.png" }
            );
    }
}
