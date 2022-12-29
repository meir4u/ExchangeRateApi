using ExchangeRate.Infrastructure.BackgroundServices.UpdateCurrencies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Infrastructure
{
    public static class InfrastructureServiceConfiguration
    {
        public static IServiceCollection ConfigurationInfrastructureService(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<UpdateCurrenciesBackgroundServiceSettings>(configuration.GetSection("UpdateCurrenciesBackgroundServiceSettings"));
            // Register Hosted Services
            service.AddHostedService<UpdateCurrenciesBackgroundService>();
            return service;
        }
    }
}
