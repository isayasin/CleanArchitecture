﻿
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.WebApi.OptionsSetup;

namespace CleanArchitecture.WebApi.Configuration;

public sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();
    }
}
