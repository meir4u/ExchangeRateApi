using ExchangeRate.Provider.CurrencyDataAPI.Base;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Provider.CurrencyDataAPI.Actions.GetExchangeRate
{
    public class GetExchangeRateConfiguration : IActionConfiguration
    {
        public string AppKey { get; } = "HO37bxfEq5zthZF6xwhX9T3fAJMc3Loc";
        public string BaseUrl { get; } = "https://api.apilayer.com/currency_data/";
        //public string BaseUrl { get; } = "https://api.exchangeratesapi.io/v1/";
        //public string ApiUrl { get; } = "exchangerates_data/latest";
        public string ApiUrl { get; } = "live?access_key=";
        public Method MethodType { get; } = Method.Get;
    }
}
