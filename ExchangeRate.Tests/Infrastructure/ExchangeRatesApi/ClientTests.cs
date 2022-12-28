using ExchangeRate.CurrencyDataAPI.Actions.GetExchangeRate;
using ExchangeRate.CurrencyDataAPI.Base;
using ExchangeRate.CurrencyDataAPI.Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Tests.Infrastructure.ExchangeRatesApi
{
    public class ClientTests
    {
        private GetExchangeRateConfiguration config;
        private ExchangeRateApiClient<GetExchangeRateRequest, GetExchangeRateResponse, GetExchangeRateConfiguration> actionClient;

        [SetUp]
        public void Setup()
        {
            this.config = new GetExchangeRateConfiguration();
            this.actionClient = new GetExchangeRateAction(config);
        }

        [Test]
        public void Valid_Request_Response_Not_Null_Test()
        {
            GetExchangeRateRequest request = new GetExchangeRateRequest()
            {
                CurrencyFrom = Domain.EApi.Currency.USD,
                CurrencyTo = Domain.EApi.Currency.GBP
            };

            var response = Task.Run(() => actionClient.Execute(request)).Result;
            Assert.That(response, Is.Not.Null);
            Assert.That(response.source, Is.EqualTo(request.CurrencyFrom.ToString()));
            Assert.That(response.quotes, Is.Not.Empty);
            Assert.That(response.quotes.ContainsKey($"{request.CurrencyFrom.ToString().ToUpper()}{request.CurrencyTo.ToString().ToUpper()}"), Is.True);
            Assert.That(response.quotes[$"{request.CurrencyFrom.ToString().ToUpper()}{request.CurrencyTo.ToString().ToUpper()}"], Is.GreaterThan(0));
        }
    }
}
