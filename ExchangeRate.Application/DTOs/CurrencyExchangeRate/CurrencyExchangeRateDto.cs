using ExchangeRate.Application.DTOs.CurrencyExchangeRate.Interfaces;
using ExchangeRate.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.DTOs.CurrencyExchangeRate
{
    [Serializable]
    public class CurrencyExchangeRateDto : ICurrencyExchangeRateDto
    {
        public string CoupleName { get=> $"{CurrencyFrom}/{CurrencyTo}"; }
        public EApi.Currency CurrencyFrom { get; set; }
        public EApi.Currency CurrencyTo { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
