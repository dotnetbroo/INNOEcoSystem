using INNOEcoSystem.Data.DbContexts;
using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Data.IRepositories.Depsrtments;

namespace INNOEcoSystem.Data.Repositories.Departments;

public class DepartmentRepositorycs : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepositorycs(AppDbContext dbContext) : base(dbContext)
    {
    }
}
