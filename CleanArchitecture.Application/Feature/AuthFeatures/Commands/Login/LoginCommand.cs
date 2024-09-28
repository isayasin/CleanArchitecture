using MediatR;

namespace CleanArchitecture.Application.Feature.AuthFeatures.Commands.Login;
public sealed record LoginCommand(
    string UserNameOrEmail,
    string Password) : IRequest<LoginCommandResponse>;
