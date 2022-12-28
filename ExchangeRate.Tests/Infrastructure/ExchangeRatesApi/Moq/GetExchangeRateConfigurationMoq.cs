using ExchangeRate.ExchangeRatesApi.Actions.GetExchangeRate;
using ExchangeRate.ExchangeRatesApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Tests.Infrastructure.ExchangeRatesApi.Moq
{
    public class GetExchangeRateConfigurationMoq
    {
        public IActionConfiguration Get()
        {
            var data = new GetExchangeRateConfiguration();
            return data;
        }
    }
}
