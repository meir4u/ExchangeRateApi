using ExchangeRate.CurrencyDataAPI.Actions.GetExchangeRate;
using ExchangeRate.CurrencyDataAPI.Base;
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
