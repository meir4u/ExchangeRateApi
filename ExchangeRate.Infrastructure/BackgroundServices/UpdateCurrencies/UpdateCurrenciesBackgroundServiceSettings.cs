using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Infrastructure.BackgroundServices.UpdateCurrencies
{
    public class UpdateCurrenciesBackgroundServiceSettings
    {
        public int TaskDelayInMinuts { get; set; }
        public string ExchangeRatePairs { get; set; }
    }
}
