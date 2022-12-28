using ExchangeRate.Application.Contract.Infrastructure;
using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using ExchangeRate.Provider.CurrencyDataAPI.Actions.GetExchangeRate;
using ExchangeRate.Provider.CurrencyDataAPI.Client;
using ExchangeRate.Provider.CurrencyDataAPI.Mapper;
using System;
using System.Threading.Tasks;

namespace ExchangeRate.Provider.CurrencyDataAPI
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
