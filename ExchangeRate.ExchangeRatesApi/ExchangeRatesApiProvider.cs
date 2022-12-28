using ExchangeRate.Application.Contract.Infrastructure;
using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using ExchangeRate.CurrencyDataAPI.Actions.GetExchangeRate;
using ExchangeRate.CurrencyDataAPI.Client;
using ExchangeRate.CurrencyDataAPI.Mapper;
using System;
using System.Threading.Tasks;

namespace ExchangeRate.CurrencyDataAPI
{
    public class ExchangeRatesApiProvider : IExchangeRatesApiProvider
    {
        private readonly ExchangeRateApiClient<GetExchangeRateRequest, GetExchangeRateResponse, GetExchangeRateConfiguration> getExchangeRateAction;

        public ExchangeRatesApiProvider(
            ExchangeRateApiClient<GetExchangeRateRequest, GetExchangeRateResponse, GetExchangeRateConfiguration> getExchangeRateAction
            )
        {
            this.getExchangeRateAction = getExchangeRateAction;
        }
        public async Task<UpdateExchangeRateDetailsResponse> GetExchangeRates(UpdateCurrencyExchangeRateDto updateCurrencyExchangeRateDto)
        {
            var providerModel = updateCurrencyExchangeRateDto.MapToGetExchangeRateRequest();
            var actionResult = await getExchangeRateAction.Execute(providerModel);
            var response = actionResult.MapToGetExchangeRateRequest();
            return response;
        }
    }
}
