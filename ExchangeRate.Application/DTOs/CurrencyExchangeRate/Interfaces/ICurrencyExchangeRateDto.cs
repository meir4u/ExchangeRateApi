using ExchangeRate.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.DTOs.CurrencyExchangeRate.Interfaces
{
    public interface ICurrencyExchangeRateDto
    {
        EApi.Currency CurrencyFrom { get; set; }
        EApi.Currency CurrencyTo { get; set; }
    }
}
