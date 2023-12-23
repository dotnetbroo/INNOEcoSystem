using INNOEcoSystem.Data.DbContexts;
using INNOEcoSystem.Data.IRepositories;
using INNOEcoSystem.Domain.Entities.Applications;

namespace INNOEcoSystem.Data.Repositories;

public class ApplicationRepository : Repository<Application>, IApplicationRepository
{
    public ApplicationRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
