using AutoMapper;
using CleanArchitecture.Application.Feature.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Feature.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Feature.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Application.Feature.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Mappings;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCarCommand, Car>();
        CreateMap<RegisterCommand, User>();
        CreateMap<CreateRoleCommand, Role>();
        CreateMap<CreateUserRoleCommand, UserRole>();
    }
}
