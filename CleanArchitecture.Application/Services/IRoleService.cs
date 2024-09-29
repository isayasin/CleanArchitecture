using CleanArchitecture.Application.Feature.RoleFeatures.Commands.CreateRole;

namespace CleanArchitecture.Application.Services;
public interface IRoleService
{
    Task CreateAsync(CreateRoleCommand request);
}
