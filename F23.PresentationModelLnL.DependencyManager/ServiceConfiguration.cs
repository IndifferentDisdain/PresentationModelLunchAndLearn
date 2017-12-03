﻿using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Contracts.Services;
using F23.PresentationModelLnL.Presentation.CaseSheets;
using F23.PresentationModelLnL.Repositories;
using F23.PresentationModelLnL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace F23.PresentationModelLnL.DependencyManager
{
    public static class ServiceConfiguration
    {
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppDatabase")));

            AddRepositories(services);
            AddServices(services);
            AddPresentationFactories(services);
        }

        private static void AddPresentationFactories(IServiceCollection services)
        {
            services.AddScoped<ICaseSheetPresentationFactory, CaseSheetPresentationFactory>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ICaseSheetRepository, CaseSheetRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ICaseSheetService, CaseSheetService>();
        }
    }
}
