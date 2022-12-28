using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Provider.CurrencyDataAPI.Base
{
    public interface IActionConfiguration
    {
        string ApiUrl { get; }
        Method MethodType { get; }
    }
}
