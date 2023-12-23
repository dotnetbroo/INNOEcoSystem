
using INNOEcoSystem.Data.IRepositories;
using INNOEcoSystem.Data.IRepositories.Categories;
using INNOEcoSystem.Data.IRepositories.Users;
using INNOEcoSystem.Data.Repositories;
using INNOEcoSystem.Data.Repositories.Categories;
using INNOEcoSystem.Data.Repositories.Users;
using INNOEcoSystem.Service.Interfaces.Accaunts;
using INNOEcoSystem.Service.Interfaces.Departments;
using INNOEcoSystem.Service.Interfaces.Locations;
using INNOEcoSystem.Service.Interfaces.User;
using INNOEcoSystem.Service.Services.Accaunts;
using INNOEcoSystem.Service.Services.Departments;
using INNOEcoSystem.Service.Services.Locations;
using INNOEcoSystem.Service.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace INNOEcoSystem.Shared.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Category
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        // User
        services.AddScoped<IUserService, UserService>();

        // Address
        services.AddScoped<IAddressService, AddressService>();

        // Email
        services.AddScoped<IEmailService, EmailService>();

    }
}
