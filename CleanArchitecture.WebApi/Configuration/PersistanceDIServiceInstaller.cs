
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Models;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories;
using CleanArchitecture.Persistance.Services;
using CleanArchitecture.WebApi.Middleware;
using GenericRepository;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.WebApi.Configuration;

public sealed class PersistanceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICarService, CarServices>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserRoleService, UserRoleService>();

        services.AddTransient<ExceptionMiddleware>();
        services.AddScoped<IUnitOfWork>(cfr => cfr.GetRequiredService<AppDbContext>());
        services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
        services.AddScoped<IMailService, MailService>(provider => new MailService(provider.GetRequiredService<IOptions<SmtpSettings>>()));
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();

    }
}
