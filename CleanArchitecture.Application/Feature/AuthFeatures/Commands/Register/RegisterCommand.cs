using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Feature.AuthFeatures.Commands.Register;
public sealed record RegisterCommand(
    string Email,
    string UserName,
    string NameLastName,
    string Password) : IRequest<MessageResponse>;
