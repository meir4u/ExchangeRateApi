using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using ExchangeRate.Application.Responses;
using ExchangeRate.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.Futures.CurrencyExchangeRate.Requests.Commands
{
    public class UpdateExchangeRateDetailsCommand : IRequest<UpdateExchangeRateDetailsResponse>
    {
        public UpdateCurrencyExchangeRateDto UpdateCurrencyExchangeRateDto;
    }
}
