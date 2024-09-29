
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CleanArchitecture.WebApi.Configuration;

public sealed class PersistanceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
    {
        services.AddAutoMapper(typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly);

        string connectionString = configuration.GetConnectionString("SqlServer");
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        services.AddIdentity<User, Role>(/*options => 
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.ReqiredLength = 1;
            options.Password.requiredUpperCase = false;
        }*/)
            .AddEntityFrameworkStores<AppDbContext>();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(
            connectionString: connectionString,
            tableName: "Logs",
            autoCreateSqlTable: true)
            .CreateLogger();

        hostBuilder.UseSerilog();
    }
}
