using ExchangeRate.ExchangeRatesApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.ExchangeRatesApi.Actions.GetExchangeRate
{
    public class GetExchangeRateResponse : IActionResponse
    {
        public string @base { get; set; }
        public string date { get; set; }
        public Dictionary <string, decimal>rates { get; set; }
        public bool success {get;set;}
        public int timestamp {get;set;}

    }
}
