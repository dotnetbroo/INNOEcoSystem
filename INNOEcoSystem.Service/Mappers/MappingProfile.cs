﻿using AutoMapper;
using INNOEcoSystem.Domain.Entities.Applications;
using INNOEcoSystem.Domain.Entities.Assets;
using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Domain.Entities.Locations;
using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Service.DTOs.Address;
using INNOEcoSystem.Service.DTOs.Applications;
using INNOEcoSystem.Service.DTOs.Categories;
using INNOEcoSystem.Service.DTOs.Department;
using INNOEcoSystem.Service.DTOs.Departments;
using INNOEcoSystem.Service.DTOs.Locations;
using INNOEcoSystem.Service.DTOs.LocationsAsset;
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
        CreateMap<User, UserForChangePasswordDto>().ReverseMap();
        CreateMap<User, UserImageResultDto>().ReverseMap();
        CreateMap<User, UserImageUpdateDto>().ReverseMap();

        // Category
        CreateMap<Category, CategoryForCreationDto>().ReverseMap();
        CreateMap<Category, CategoryForUpdateDto>().ReverseMap();
        CreateMap<Category, CategoryForResultDto>().ReverseMap();
        CreateMap<Category, CategoryImageForResultDto>().ReverseMap();
        CreateMap<Category, CategoryImageForUpdateDto>().ReverseMap();

        // UserAddress
        CreateMap<Address, AddressForResultDto>().ReverseMap();
        CreateMap<Address, AddressForUpdateDto>().ReverseMap();
        CreateMap<Address, AddressForCreationDto>().ReverseMap();


        //Department
        CreateMap<Department, DepartmentForCreationDto>().ReverseMap();
        CreateMap<Department, DepartmentForResultDto>().ReverseMap();
        CreateMap<Department, DepartmentForUpdateDto>().ReverseMap();

        // Location
        CreateMap<Location, LocationForCreationDto>().ReverseMap();
        CreateMap<Location, LocationForUpdateDto>().ReverseMap();
        CreateMap<Location, LocationForResultDto>().ReverseMap();

        // Application
        CreateMap<Application, ApplicationForCreationDto>().ReverseMap();
        CreateMap<Application, ApplicationForResultDto>().ReverseMap();
        CreateMap<Application, ApplicationForUpdateDto>().ReverseMap();

        //LocationAsset
        CreateMap<LocationAsset, LocationAssetForResultDto>().ReverseMap();
        CreateMap<LocationAsset, LocationAssetForCreationDto>().ReverseMap();
        CreateMap<LocationAsset, LocationAssetForUpdateDto>().ReverseMap();
    }
}
