
using INNOEcoSystem.Data.IRepositories.Categories;
using INNOEcoSystem.Data.IRepositories.Locations;
using INNOEcoSystem.Data.Repositories.Categories;
using INNOEcoSystem.Data.Repositories.Locations;
using INNOEcoSystem.Domain.Entities.Locations;
using INNOEcoSystem.Service.Interfaces.Departments;
using INNOEcoSystem.Service.Interfaces.Location;
using INNOEcoSystem.Service.Services.Departments;
using INNOEcoSystem.Service.Services.Locations;
using Microsoft.Extensions.DependencyInjection;

namespace INNOEcoSystem.Shared.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        // Category
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        // Location
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<ILocationRepository, LocationRepository>();
    }
}
