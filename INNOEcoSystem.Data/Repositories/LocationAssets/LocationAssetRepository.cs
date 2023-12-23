using INNOEcoSystem.Data.DbContexts;
using INNOEcoSystem.Data.IRepositories.LocationAssets;
using INNOEcoSystem.Domain.Entities.Assets;

namespace INNOEcoSystem.Data.Repositories.LocationAssets;

public class LocationAssetRepository : Repository<LocationAsset>, ILocationAssetRepository
{
    public LocationAssetRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
