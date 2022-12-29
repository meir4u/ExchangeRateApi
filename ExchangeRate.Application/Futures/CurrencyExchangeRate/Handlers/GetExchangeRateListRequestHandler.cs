using ExchangeRate.Application.Contract.Persistence;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Requests.Queries;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Futures.CurrencyExchangeRate.Handlers.Queries
{
    public class GetExchangeRateListRequestHandler : IRequestHandler<GetExchangeRateListRequest, GetExchangeRateListResponse>
    {
        private readonly ICurrencyExchangeRateRepository _currencyExchangeRateRepository;

        public GetExchangeRateListRequestHandler(ICurrencyExchangeRateRepository currencyExchangeRateRepository)
        {
            this._currencyExchangeRateRepository = currencyExchangeRateRepository;
        }
        public async Task<GetExchangeRateListResponse> Handle(GetExchangeRateListRequest request, CancellationToken cancellationToken)
        {
            var result = new GetExchangeRateListResponse();
            var task = Task.Factory.StartNew(()=>_currencyExchangeRateRepository.GetAll());
            var data = await task;
            result.CurrencyExchangeRateDto = data.ToList();
            return result;
        }
    }
}
