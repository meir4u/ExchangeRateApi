using ExchangeRate.Application.Contract.Persistence;
using ExchangeRate.Persistence.Repository.CurrencyExchangeRateRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CurrencyExchangeRateRepositorySettings>(configuration.GetSection("CurrencyExchangeRateRepository"));
            services.AddSingleton<ICurrencyExchangeRateRepository, CurrencyExchangeRateRepository>();
            return services;
        }
    }
}
