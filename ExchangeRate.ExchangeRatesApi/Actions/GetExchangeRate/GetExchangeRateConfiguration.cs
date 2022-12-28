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
        public string ApiUrl { get; } = "live?access_key=";
        public Method MethodType { get; } = Method.Get;
    }
}
