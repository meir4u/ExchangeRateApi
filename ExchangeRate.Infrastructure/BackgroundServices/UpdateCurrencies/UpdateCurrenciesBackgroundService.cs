using ExchangeRate.Application.Contract.Infrastructure;
using ExchangeRate.Application.Contract.Persistence;
using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Domain;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRate.Infrastructure.BackgroundServices.UpdateCurrencies
{
    public class UpdateCurrenciesBackgroundService : BackgroundService
    {
        private readonly IOptions<UpdateCurrenciesBackgroundServiceSettings> _options;
        private readonly IExchangeRatesApiProvider _exchangeRatesApiProvider;
        private readonly ICurrencyExchangeRateRepository _currencyExchangeRateRepository;

        public UpdateCurrenciesBackgroundService(
            IOptions<UpdateCurrenciesBackgroundServiceSettings> options,
            IExchangeRatesApiProvider exchangeRatesApiProvider,
            ICurrencyExchangeRateRepository currencyExchangeRateRepository
            )
        {
            this._options = options;
            this._exchangeRatesApiProvider = exchangeRatesApiProvider;
            this._currencyExchangeRateRepository = currencyExchangeRateRepository;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            IEnumerable<string> exchagnePairs = getExchangePairs();
            IEnumerable<UpdateCurrencyExchangeRateDto> currencyExchangeRateRequestList = getCurrencyExchangeRateRequestList(exchagnePairs);
            while (!stoppingToken.IsCancellationRequested)
            {
                // Your code here
                IEnumerable<CurrencyExchangeRateDto> exchangeRateList = await getExchangeRateList(currencyExchangeRateRequestList);
                _currencyExchangeRateRepository.UpdateAll(exchangeRateList);
                await Task.Delay(TimeSpan.FromMinutes(_options.Value.TaskDelayInMinuts), stoppingToken);
            }
        }

        private async Task<IEnumerable<CurrencyExchangeRateDto>> getExchangeRateList(IEnumerable<UpdateCurrencyExchangeRateDto> currencyExchangeRateRequestList)
        {
            List<CurrencyExchangeRateDto> data = new List<CurrencyExchangeRateDto>();
            foreach (var item in currencyExchangeRateRequestList)
            {
                var tmpResult = await _exchangeRatesApiProvider.GetExchangeRates(item);
                data.Add(tmpResult.CurrencyExchangeRateDto);
            }
            return data;
        }

        private IEnumerable<UpdateCurrencyExchangeRateDto> getCurrencyExchangeRateRequestList(IEnumerable<string> exchagnePairs)
        {
            List<UpdateCurrencyExchangeRateDto> data = new List<UpdateCurrencyExchangeRateDto>();
            foreach (var item in exchagnePairs)
            {
                try
                {
                    var tmpDto = new UpdateCurrencyExchangeRateDto()
                    {
                        CurrencyFrom = (EApi.Currency)Enum.Parse(typeof(EApi.Currency), item.Split('/')[0]),
                        CurrencyTo = (EApi.Currency)Enum.Parse(typeof(EApi.Currency), item.Split('/')[1]),
                    };
                    data.Add(tmpDto);

                }catch(Exception ex)
                {

                }
            }
            return data;
        }

        private IEnumerable<string> getExchangePairs()
        {
            var splited = _options.Value.ExchangeRatePairs.Split(',');
            return splited;
        }
    }
}
