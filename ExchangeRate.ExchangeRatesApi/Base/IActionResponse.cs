using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Provider.CurrencyDataAPI.Base
{
    public interface IActionResponse
    {
        string source { get; set; }
        Dictionary<string, decimal> quotes { get; set; }
        bool success { get; set; }
        int timestamp { get; set; }
    }
}
