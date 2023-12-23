using INNOEcoSystem.Data.IRepositories;
using INNOEcoSystem.Data.IRepositories.Categories;
using INNOEcoSystem.Data.IRepositories.Depsrtments;
using INNOEcoSystem.Data.IRepositories.LocationAssets;
using INNOEcoSystem.Data.IRepositories.Locations;
using INNOEcoSystem.Data.IRepositories.Users;
using INNOEcoSystem.Data.Repositories;
using INNOEcoSystem.Data.Repositories.Categories;
using INNOEcoSystem.Data.Repositories.Departments;
using INNOEcoSystem.Data.Repositories.LocationAssets;
using INNOEcoSystem.Data.Repositories.Locations;
using INNOEcoSystem.Data.Repositories.Users;
using INNOEcoSystem.Service.Interfaces.Accaunts;
using INNOEcoSystem.Service.Interfaces.Accounts;
using INNOEcoSystem.Service.Interfaces.Applications;
using INNOEcoSystem.Service.Interfaces.Commons;
using INNOEcoSystem.Service.Interfaces.Department;
using INNOEcoSystem.Service.Interfaces.Departments;
using INNOEcoSystem.Service.Interfaces.Location;
using INNOEcoSystem.Service.Interfaces.LocationAssets;
using INNOEcoSystem.Service.Interfaces.Locations;
using INNOEcoSystem.Service.Interfaces.User;
using INNOEcoSystem.Service.Services;
using INNOEcoSystem.Service.Services.Accaunts;
using INNOEcoSystem.Service.Services.Applications;
using INNOEcoSystem.Service.Services.Commons;
using INNOEcoSystem.Service.Services.Departments;
using INNOEcoSystem.Service.Services.Locations;
using INNOEcoSystem.Service.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace INNOEcoSystem.Shared.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IApplicationRepository, ApplicationRepository>();

        // Category
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        //Department 
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        // Location
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<ILocationRepository, LocationRepository>();

        // User
        services.AddScoped<IUserService, UserService>();


        // Address
        services.AddScoped<IAddressService, AddressService>();

        // Email
        services.AddScoped<IEmailService, EmailService>();

        // Application
        services.AddScoped<IApplicationService, ApplicationService>();

        //LocationAsset
        services.AddScoped<ILocationAssetRepository,LocationAssetRepository>();
        services.AddScoped<ILocationAssetService, LocationAssetService>();

        // Email
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ISmsService, SmsService>();
        services.AddScoped<IAccountService, AccountService>();
    }

    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var Key = Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]);
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ClockSkew = TimeSpan.FromMinutes(1)
            };
        });
    }
}
