using System;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace F23.PresentationModelLnL.DependencyManager
{
    public static class ServiceConfiguration
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ICaseSheetRepository, CaseSheetRepository>();
        }
    }
}
