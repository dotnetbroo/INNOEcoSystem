using INNOEcoSystem.Data.DbContexts;
using INNOEcoSystem.Data.IRepositories.Users;
using INNOEcoSystem.Domain.Entities.Users;

namespace INNOEcoSystem.Data.Repositories.Users;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
