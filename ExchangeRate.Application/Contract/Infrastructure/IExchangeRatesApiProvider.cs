using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Contract.Infrastructure
{
    public interface IExchangeRatesApiProvider
    {
        Task<UpdateExchangeRateDetailsResponse> GetExchangeRates(DTOs.CurrencyExchangeRate.UpdateCurrencyExchangeRateDto updateCurrencyExchangeRateDto);
    }
}
