
using INNOEcoSystem.Data.IRepositories.Categories;
using INNOEcoSystem.Data.Repositories.Categories;
using INNOEcoSystem.Service.Interfaces.Departments;
using INNOEcoSystem.Service.Services.Departments;
using Microsoft.Extensions.DependencyInjection;

namespace INNOEcoSystem.Shared.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        // Category
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

    }
}
