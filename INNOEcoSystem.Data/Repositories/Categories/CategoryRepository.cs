using INNOEcoSystem.Data.DbContexts;
using INNOEcoSystem.Data.IRepositories.Categories;
using INNOEcoSystem.Domain.Entities.Departments;

namespace INNOEcoSystem.Data.Repositories.Categories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
