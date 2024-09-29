using AutoMapper;
using CleanArchitecture.Application.Feature.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Persistance.Services;
public sealed class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;

    public RoleService(RoleManager<Role> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateRoleCommand request)
    {
        Role role = _mapper.Map<Role>(request);

        /*Role role = new()
        {
            Name = request.Name,
        };*/

        await _roleManager.CreateAsync(role);
    }
}
