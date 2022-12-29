using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Domain
{
    [Serializable]
    public class CurrencyExchangeRate
    {
        public EApi.Currency CurrencyFrom { get; set; }
        public EApi.Currency CurrencyTo { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
