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
            //service.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            return service;
        }
    }
}
