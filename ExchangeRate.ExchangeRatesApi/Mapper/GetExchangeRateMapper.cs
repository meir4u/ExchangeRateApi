using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using ExchangeRate.Domain;
using ExchangeRate.ExchangeRatesApi.Actions.GetExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.ExchangeRatesApi.Mapper
{
    public static class GetExchangeRateMapper
    {
        public static GetExchangeRateRequest MapToGetExchangeRateRequest(this UpdateCurrencyExchangeRateDto updateCurrencyExchangeRateDto)
        {
            var model = new GetExchangeRateRequest()
            {
                CurrencyFrom = updateCurrencyExchangeRateDto.CurrencyFrom,
                CurrencyTo = updateCurrencyExchangeRateDto.CurrencyTo
            };

            return model;
        }

        public static UpdateExchangeRateDetailsResponse MapToGetExchangeRateRequest(this GetExchangeRateResponse updateCurrencyExchangeRateDto)
        {
            object tempCurrency = EApi.Currency.None;
            var model = new UpdateExchangeRateDetailsResponse()
            {
                CurrencyExchangeRateDto = new CurrencyExchangeRateDto()
                {
                    CurrencyFrom = enumParser(updateCurrencyExchangeRateDto.@base),
                    CurrencyTo = enumParser(updateCurrencyExchangeRateDto.rates.FirstOrDefault().Key),
                    ExchangeRate = updateCurrencyExchangeRateDto.rates.FirstOrDefault().Value,
                    UpdatedAt = DateTime.Now
                },
                Success = true
            };

            return model;
        }

        private static EApi.Currency enumParser(string toParse)
        {
            object tempCurrency = EApi.Currency.None;
            var data = Enum.TryParse(typeof(EApi.Currency), toParse, true, out tempCurrency) ? (EApi.Currency)tempCurrency : throw new Exception($"Failed To parse currency '{toParse}'");
            return data;
        }
    }
}
