using INNOEcoSystem.Data.DbContexts;
using INNOEcoSystem.Data.IRepositories.Depsrtments;
using INNOEcoSystem.Domain.Entities.Departments;

namespace INNOEcoSystem.Data.Repositories.Departments;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
