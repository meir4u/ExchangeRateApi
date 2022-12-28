using ExchangeRate.Domain;
using ExchangeRate.ExchangeRatesApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.ExchangeRatesApi.Actions.GetExchangeRate
{
    public class GetExchangeRateRequest : IActionRequest
    {
        public EApi.Currency CurrencyFrom { get; set; }
        public EApi.Currency CurrencyTo { get; set; }

        public string UrlQuery => $"&symbols={CurrencyFrom.ToString().ToUpper()}&base={CurrencyTo.ToString().ToUpper()}";
    }
}
