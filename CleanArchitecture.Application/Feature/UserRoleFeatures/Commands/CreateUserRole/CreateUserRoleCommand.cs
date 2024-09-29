using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Feature.UserRoleFeatures.Commands.CreateUserRole;
public sealed record CreateUserRoleCommand(string RoleId, string UserId) : IRequest<MessageResponse>;
