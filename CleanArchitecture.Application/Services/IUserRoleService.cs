using CleanArchitecture.Application.Feature.UserRoleFeatures.Commands.CreateUserRole;

namespace CleanArchitecture.Application.Services;
public interface IUserRoleService
{
    Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken);
}
