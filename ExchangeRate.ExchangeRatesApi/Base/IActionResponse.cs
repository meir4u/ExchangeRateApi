using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.ExchangeRatesApi.Base
{
    public interface IActionResponse
    {
        string @base { get; set; }
        string date { get; set; }
        Dictionary<string, decimal> rates { get; set; }
        bool success { get; set; }
        int timestamp { get; set; }
    }
}
