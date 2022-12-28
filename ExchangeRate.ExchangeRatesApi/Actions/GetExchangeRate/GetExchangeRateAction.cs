using ExchangeRate.ExchangeRatesApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate.ExchangeRatesApi.Client;

namespace ExchangeRate.ExchangeRatesApi.Actions.GetExchangeRate
{
    public class GetExchangeRateAction : ExchangeRateApiClient<GetExchangeRateRequest, GetExchangeRateResponse, GetExchangeRateConfiguration>
    {
        public GetExchangeRateAction(GetExchangeRateConfiguration getExchangeRateConfiguration)
            :base(getExchangeRateConfiguration)
        {

        }
    }
}
