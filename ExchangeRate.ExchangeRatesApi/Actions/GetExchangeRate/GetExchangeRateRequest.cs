using ExchangeRate.Domain;
using ExchangeRate.Provider.CurrencyDataAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Provider.CurrencyDataAPI.Actions.GetExchangeRate
{
    public class GetExchangeRateRequest : IActionRequest
    {
        public EApi.Currency CurrencyFrom { get; set; }
        public EApi.Currency CurrencyTo { get; set; }

        public string UrlQuery => $"&source={CurrencyFrom.ToString().ToUpper()}&currencies={CurrencyTo.ToString().ToUpper()}";
    }
}
