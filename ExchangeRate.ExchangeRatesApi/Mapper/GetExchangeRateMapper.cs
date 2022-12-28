using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using ExchangeRate.Domain;
using ExchangeRate.Provider.CurrencyDataAPI.Actions.GetExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Provider.CurrencyDataAPI.Mapper
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
                    CurrencyFrom = enumParser(updateCurrencyExchangeRateDto.source),
                    CurrencyTo = enumParser(updateCurrencyExchangeRateDto.quotes.FirstOrDefault().Key.Replace(updateCurrencyExchangeRateDto.source, "")),
                    ExchangeRate = updateCurrencyExchangeRateDto.quotes.FirstOrDefault().Value,
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
