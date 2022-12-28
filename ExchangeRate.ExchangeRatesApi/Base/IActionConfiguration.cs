﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.CurrencyDataAPI.Base
{
    public interface IActionConfiguration
    {
        string AppKey { get; }
        string BaseUrl { get; }
        string ApiUrl { get; }
        Method MethodType { get; }
    }
}
