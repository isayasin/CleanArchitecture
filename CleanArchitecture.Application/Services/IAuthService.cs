﻿using CleanArchitecture.Application.Feature.AuthFeatures.Commands.Register;

namespace CleanArchitecture.Application.Services;
public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request);
}