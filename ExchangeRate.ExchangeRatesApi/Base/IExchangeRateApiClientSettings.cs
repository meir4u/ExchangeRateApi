using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Provider.CurrencyDataAPI.Base
{
    public interface IExchangeRateApiClientSettings
    {
        string BaseUrl { get; set; }
        string AppKey { get; set; }
        int MaxTimeout { get; set; }
    }
}
