using INNOEcoSystem.Data.DbContexts;
using INNOEcoSystem.Data.IRepositories.Users;
using INNOEcoSystem.Domain.Entities.Locations;

namespace INNOEcoSystem.Data.Repositories.Users;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
