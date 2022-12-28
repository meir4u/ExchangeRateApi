using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExchangeRate.CurrencyDataAPI
{
    public static class ExchangeRatesApiServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
