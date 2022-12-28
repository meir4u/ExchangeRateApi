using ExchangeRate.Application.Contract.Infrastructure;
using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using ExchangeRate.ExchangeRatesApi.Actions.GetExchangeRate;
using ExchangeRate.ExchangeRatesApi.Client;
using ExchangeRate.ExchangeRatesApi.Mapper;
using System;
using System.Threading.Tasks;

namespace ExchangeRate.ExchangeRatesApi
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
