using ExchangeRate.Provider.CurrencyDataAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Provider.CurrencyDataAPI.Client
{
    public class ExchangeRateApiClientSettings : IExchangeRateApiClientSettings
    {
        public string BaseUrl { get; set; }
        public string AppKey { get; set; }
        public int MaxTimeout { get; set; }
    }
}
