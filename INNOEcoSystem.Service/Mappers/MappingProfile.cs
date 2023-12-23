using AutoMapper;
using INNOEcoSystem.Domain.Entities.Applications;
using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Domain.Entities.Locations;
using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Service.DTOs.Applications;
using INNOEcoSystem.Service.DTOs.Categories;
using INNOEcoSystem.Service.DTOs.Department;
using INNOEcoSystem.Service.DTOs.Departments;
using INNOEcoSystem.Service.DTOs.Locations;
using INNOEcoSystem.Service.DTOs.Users;

namespace INNOEcoSystem.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();

        // Category
        CreateMap<Category, CategoryForCreationDto>().ReverseMap();
        CreateMap<Category, CategoryForUpdateDto>().ReverseMap();
        CreateMap<Category, CategoryForResultDto>().ReverseMap();

        //Department
        CreateMap<Department,DepartmentForCreationDto>().ReverseMap();
        CreateMap<Department,DepartmentForResultDto>().ReverseMap();
        CreateMap<Department,DepartmentForUpdateDto>().ReverseMap();

        // Location
        CreateMap<Location, LocationForCreationDto>().ReverseMap();
        CreateMap<Location, LocationForUpdateDto>().ReverseMap();
        CreateMap<Location, LocationForResultDto>().ReverseMap();

        // Application
        CreateMap<Application, ApplicationForCreationDto>().ReverseMap();
        CreateMap<Application, ApplicationForResultDto>().ReverseMap();
        CreateMap<Application, ApplicationForUpdateDto>().ReverseMap();

    }
}
