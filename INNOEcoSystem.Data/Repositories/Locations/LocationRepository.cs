using INNOEcoSystem.Data.DbContexts;
using INNOEcoSystem.Data.IRepositories.Locations;
using INNOEcoSystem.Domain.Entities.Locations;

namespace INNOEcoSystem.Data.Repositories.Locations;

public class LocationRepository : Repository<Location>, ILocationRepository
{
    public LocationRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
