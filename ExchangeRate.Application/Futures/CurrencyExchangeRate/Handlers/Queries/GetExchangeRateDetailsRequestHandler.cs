using ExchangeRate.Application.Futures.CurrencyExchangeRate.Requests.Queries;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Futures.CurrencyExchangeRate.Handlers.Queries
{
    public class GetExchangeRateDetailsRequestHandler : IRequestHandler<GetExchangeRateDetailsRequest, GetExchangeRateDetailsResponse>
    {
        public Task<GetExchangeRateDetailsResponse> Handle(GetExchangeRateDetailsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
