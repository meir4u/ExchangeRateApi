using ExchangeRate.Application.DTOs.CurrencyExchangeRate.Interfaces;
using ExchangeRate.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.DTOs.CurrencyExchangeRate
{
    public class UpdateCurrencyExchangeRateDto : ICurrencyExchangeRateDto
    {
        public EApi.Currency CurrencyFrom { get; set; }
        public EApi.Currency CurrencyTo { get; set; }
    }
}
