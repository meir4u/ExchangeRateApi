using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.Futures.CurrencyExchangeRate.Requests.Queries
{
    public class GetExchangeRateDetailsRequest : IRequest<GetExchangeRateDetailsResponse>
    {
    }
}
