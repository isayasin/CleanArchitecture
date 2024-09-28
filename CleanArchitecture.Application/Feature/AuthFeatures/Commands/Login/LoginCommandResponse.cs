﻿namespace CleanArchitecture.Application.Feature.AuthFeatures.Commands.Login;
public sealed record LoginCommandResponse(
    string Token,
    string RefreshToken,
    DateTime? RefreshTokenExpires,
    string UserId,
    string UserName,
    string NameAndLastName,
    string Email);