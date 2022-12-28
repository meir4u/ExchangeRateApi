using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses;
using ExchangeRate.Provider.CurrencyDataAPI;
using ExchangeRate.Provider.CurrencyDataAPI.Actions.GetExchangeRate;
using ExchangeRate.Provider.CurrencyDataAPI.Base;
using ExchangeRate.Provider.CurrencyDataAPI.Client;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Tests.Infrastructure.Provider.CurrencyDataAPI
{
    public class ProviderCurrencyDataApiTests
    {
        private UpdateCurrencyExchangeRateDto request;
        private UpdateExchangeRateDetailsResponse response;

        [OneTimeSetUp]
        public void Setup()
        {
            var BaseUrl = "https://api.apilayer.com/currency_data/";
            var MaxTimeout = -1;
            var AppKey = "HO37bxfEq5zthZF6xwhX9T3fAJMc3Loc";

            var settings = new Mock<IOptions<IExchangeRateApiClientSettings>>();
            settings.Setup(p => p.Value.AppKey).Returns(AppKey);
            settings.Setup(p => p.Value.MaxTimeout).Returns(MaxTimeout);
            settings.Setup(p => p.Value.BaseUrl).Returns(BaseUrl);

            var config = new GetExchangeRateConfiguration();
            var actionClient = new GetExchangeRateAction(config, settings.Object);
            var providerApi = new ExchangeRatesApiProvider(actionClient);

            this.request = new UpdateCurrencyExchangeRateDto()
            {
                CurrencyFrom = Domain.EApi.Currency.USD,
                CurrencyTo = Domain.EApi.Currency.GBP
            };

            this.response = Task.Run(() => providerApi.GetExchangeRates(request)).Result;
        }

        [Test]
        [Order(1)]
        public void Valid_Request_Response_Not_Null_Test()
        {
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Errors, Is.Null.Or.Empty);
            Assert.That(response.CurrencyExchangeRateDto, Is.Not.Null);
            Assert.That(response.CurrencyExchangeRateDto.CurrencyFrom, Is.EqualTo(request.CurrencyFrom));
            Assert.That(response.CurrencyExchangeRateDto.CurrencyTo, Is.EqualTo(request.CurrencyTo));
            Assert.That(response.CurrencyExchangeRateDto.ExchangeRate, Is.GreaterThan(0));
            Assert.That(response.Success, Is.True);
        }
    }
}
