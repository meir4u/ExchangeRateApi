using ExchangeRate.CurrencyDataAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.CurrencyDataAPI.Actions.GetExchangeRate
{
    public class GetExchangeRateResponse : IActionResponse
    {
        public string source { get; set; }
        public Dictionary <string, decimal>quotes { get; set; }
        public bool success {get;set;}
        public int timestamp {get;set;}

    }
}
