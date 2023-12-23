
using INNOEcoSystem.Data.IRepositories;
using INNOEcoSystem.Data.IRepositories.Categories;
using INNOEcoSystem.Data.Repositories;
using INNOEcoSystem.Data.Repositories.Categories;
using INNOEcoSystem.Service.Interfaces.Applications;
using INNOEcoSystem.Service.Interfaces.Departments;
using INNOEcoSystem.Service.Interfaces.User;
using INNOEcoSystem.Service.Services.Applications;
using INNOEcoSystem.Service.Services.Departments;
using INNOEcoSystem.Service.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace INNOEcoSystem.Shared.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Category
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        // User
        services.AddScoped<IUserService, UserService>();

        // Application
        services.AddScoped<IApplicationService, ApplicationService>();


    }
}
