using ExchangeRate.ExchangeRatesApi.Actions.GetExchangeRate;
using ExchangeRate.ExchangeRatesApi.Base;
using ExchangeRate.ExchangeRatesApi.Client;
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
        }
    }
}
