using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace F23.PresentationModelLnL.DependencyManager
{
    public static class ServiceConfiguration
    {
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Repositories.AppContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppDatabase")));

            services.AddScoped<ICaseSheetRepository, CaseSheetRepository>();
        }
    }
}
