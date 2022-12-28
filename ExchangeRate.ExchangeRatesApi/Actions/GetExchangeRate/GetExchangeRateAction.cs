using ExchangeRate.Provider.CurrencyDataAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate.Provider.CurrencyDataAPI.Client;
using Microsoft.Extensions.Options;

namespace ExchangeRate.Provider.CurrencyDataAPI.Actions.GetExchangeRate
{
    public class GetExchangeRateAction : ExchangeRateApiClient<GetExchangeRateRequest, GetExchangeRateResponse, GetExchangeRateConfiguration>
    {
        public GetExchangeRateAction(GetExchangeRateConfiguration getExchangeRateConfiguration, IOptions<IExchangeRateApiClientSettings> options)
            :base(options, getExchangeRateConfiguration)
        {

        }
    }
}
