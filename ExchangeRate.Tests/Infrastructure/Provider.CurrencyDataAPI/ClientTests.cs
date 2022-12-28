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

namespace ExchangeRate.Tests.Infrastructure.ExchangeProvider.CurrencyDataAPIRatesApi
{
    //Choosen to created one call because have limited number of calls to api. 
    public class ClientTests
    {
        private GetExchangeRateConfiguration config;
        private ExchangeRateApiClient<GetExchangeRateRequest, GetExchangeRateResponse, GetExchangeRateConfiguration> actionClient;
        private GetExchangeRateRequest request;
        private GetExchangeRateResponse response;
        private readonly IOptions<ExchangeRateApiClientSettings> _options;

        [OneTimeSetUp]
        public void Setup()
        {
            var BaseUrl = "https://api.apilayer.com/currency_data/";
            var MaxTimeout = -1;
            var AppKey = "HO37bxfEq5zthZF6xwhX9T3fAJMc3Loc";

            var settings = new Mock<IOptions<IExchangeRateApiClientSettings>>();
            settings.Setup(p=>p.Value.AppKey).Returns(AppKey);
            settings.Setup(p=>p.Value.MaxTimeout).Returns(MaxTimeout);
            settings.Setup(p=>p.Value.BaseUrl).Returns(BaseUrl);

            this.config = new GetExchangeRateConfiguration();
            this.actionClient = new GetExchangeRateAction(config, settings.Object);

            this.request = new GetExchangeRateRequest()
            {
                CurrencyFrom = Domain.EApi.Currency.USD,
                CurrencyTo = Domain.EApi.Currency.GBP
            };

            this.response = Task.Run(() => actionClient.Execute(request)).Result;
        }

        [Test]
        [Order(1)]
        public void Valid_Request_Response_Not_Null_Test()
        {
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        [Order(2)]
        public void Valid_Request_Response_And_Response_source_Same_Test()
        {
            Assert.That(response.source, Is.EqualTo(request.CurrencyFrom.ToString()));
        }

        [Test]
        [Order(3)]
        public void Valid_Request_Response_Quotes_Not_Empty_Test()
        {
            Assert.That(response.quotes, Is.Not.Empty);
        }

        [Test]
        [Order(4)]
        public void Valid_Request_Response_Quotes_Contain_Requested_Key_Test()
        {
            Assert.That(response.quotes.ContainsKey($"{request.CurrencyFrom.ToString().ToUpper()}{request.CurrencyTo.ToString().ToUpper()}"), Is.True);
        }

        [Test]
        [Order(5)]
        public void Valid_Request_Response_Quotes_Value_Bigger_Then_Zero_Test()
        {
            Assert.That(response.quotes[$"{request.CurrencyFrom.ToString().ToUpper()}{request.CurrencyTo.ToString().ToUpper()}"], Is.GreaterThan(0));
        }
    }
}
