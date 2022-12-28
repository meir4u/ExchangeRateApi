using ExchangeRate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.ExchangeRatesApi.Base
{
    public interface IActionRequest
    {
        EApi.Currency CurrencyFrom { get; set; }
        EApi.Currency CurrencyTo { get; set; }

        string UrlQuery { get; }
    }
}
