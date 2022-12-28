using ExchangeRate.Application.Contract.Infrastructure;
using ExchangeRate.Application.DTOs.CurrencyExchangeRate.Validators;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Requests.Commands;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using ExchangeRate.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRate.Application.Futures.CurrencyExchangeRate.Handlers.Commands
{
    public class UpdateExchangeRateDetailsCommandHandler : IRequestHandler<UpdateExchangeRateDetailsCommand, UpdateExchangeRateDetailsResponse>
    {
        private readonly IExchangeRatesApiProvider _exchangeRatesApiProvider;

        public UpdateExchangeRateDetailsCommandHandler(
            IExchangeRatesApiProvider exchangeRatesApiProvider
            )
        {
            this._exchangeRatesApiProvider = exchangeRatesApiProvider;
        }
        public async Task<UpdateExchangeRateDetailsResponse> Handle(UpdateExchangeRateDetailsCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateExchangeRateDetailsResponse();
            var validate = new UpdateCurrencyExchangeRateDtoValidator().Validate(request.UpdateCurrencyExchangeRateDto);
            if (validate.IsValid)
            {
                response = await _exchangeRatesApiProvider.GetExchangeRates(request.UpdateCurrencyExchangeRateDto);
            }
            else
            {
                response.Success = false;
                response.Errors = validate.Errors.Select(p => p.ErrorMessage).ToList();
            }
            return response;
        }
    }
}
