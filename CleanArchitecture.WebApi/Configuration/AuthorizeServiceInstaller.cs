
namespace CleanArchitecture.WebApi.Configuration;

public class AuthorizeServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
    {
        services.AddAuthentication().AddJwtBearer();
        services.AddAuthorization();
    }
}
