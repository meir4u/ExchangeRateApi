using ExchangeRate.Provider.CurrencyDataAPI.Actions.GetExchangeRate;
using ExchangeRate.Provider.CurrencyDataAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Tests.Infrastructure.Provider.CurrencyDataAPI.Moq
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
