using INNOEcoSystem.Data.DbContexts;
using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Data.IRepositories.Depsrtments;

namespace INNOEcoSystem.Data.Repositories.Departments;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
