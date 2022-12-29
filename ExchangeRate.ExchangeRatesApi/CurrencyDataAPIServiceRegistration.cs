using ExchangeRate.Application.Contract.Infrastructure;
using ExchangeRate.Provider.CurrencyDataAPI.Actions.GetExchangeRate;
using ExchangeRate.Provider.CurrencyDataAPI.Base;
using ExchangeRate.Provider.CurrencyDataAPI.Client;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ExchangeRate.Provider.CurrencyDataAPI
{
    public static class CurrencyDataAPIServiceRegistration
    {
        public static IServiceCollection ConfigureCurrencyDataAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IExchangeRateApiClientSettings, ExchangeRateApiClientSettings>();
            services.Configure<ExchangeRateApiClientSettings>(configuration.GetSection("ExchangeRateApiClient"));

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IActionConfiguration,GetExchangeRateConfiguration>();
            services.AddSingleton<ExchangeRateApiClient<GetExchangeRateRequest, GetExchangeRateResponse, GetExchangeRateConfiguration>, GetExchangeRateAction>();
            services.AddSingleton<IExchangeRatesApiProvider, ExchangeRatesApiProvider>();
            return services;
        }
    }
}
