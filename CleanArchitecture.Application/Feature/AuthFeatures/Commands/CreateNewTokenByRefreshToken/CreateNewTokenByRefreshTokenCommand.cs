using CleanArchitecture.Application.Feature.AuthFeatures.Commands.Login;
using MediatR;

namespace CleanArchitecture.Application.Feature.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
public sealed record CreateNewTokenByRefreshTokenCommand(
    string UserId,
    string RefreshToken
) : IRequest<LoginCommandResponse>;
