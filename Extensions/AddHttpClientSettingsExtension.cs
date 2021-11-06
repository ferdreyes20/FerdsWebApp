using System;
using FerdsWebApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FerdsWebApp.Extensions
{
    public static class AddHttpClientSettingsExtension
    {
        public static IServiceCollection AddHttpClientSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<INetzweltService, NetzweltService>(c => {
                c.BaseAddress = new Uri(configuration["NetzweltApi"]);
            });

            return services;
        }
        
    }
}