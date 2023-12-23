
using INNOEcoSystem.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using INNOEcoSystem.Service.Services.Departments;
using INNOEcoSystem.Data.Repositories.Categories;
using INNOEcoSystem.Data.IRepositories.Categories;
using INNOEcoSystem.Data.Repositories.Departments;
using INNOEcoSystem.Service.Interfaces.Department;
using INNOEcoSystem.Service.Interfaces.Departments;
using INNOEcoSystem.Data.IRepositories.Depsrtments;

namespace INNOEcoSystem.Shared.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        // Category
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        //Department 
        services.AddScoped<IDepartmentService,DepartmentService>();
        services.AddScoped<IDepartmentRepository,DepartmentRepository>();


    }
}
