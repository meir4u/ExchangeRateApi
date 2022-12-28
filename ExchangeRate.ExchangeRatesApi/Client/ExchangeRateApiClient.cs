using ExchangeRate.Provider.CurrencyDataAPI.Base;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Provider.CurrencyDataAPI.Client
{
    public abstract class ExchangeRateApiClient<TReq, TRes, TConfiguration> : IAction<TReq, TRes, TConfiguration>
        where TReq : IActionRequest
        where TRes : IActionResponse
        where TConfiguration : IActionConfiguration
    {
        private readonly IOptions<IExchangeRateApiClientSettings> _options;
        private readonly TConfiguration _configuration;

        public ExchangeRateApiClient(
            IOptions<IExchangeRateApiClientSettings> options,
            TConfiguration configuration
            )
        {
            this._options = options;
            this._configuration = configuration;
        }
        public async Task<TRes> Execute(TReq request)
        {
            TRes response = default(TRes);
            var option = new RestClientOptions();
            option.BaseUrl = new Uri(_options.Value.BaseUrl);
            option.MaxTimeout = _options.Value.MaxTimeout;

            var client = new RestClient(option);


            var resourse = _configuration.ApiUrl + _options.Value.AppKey + request.UrlQuery + $"&date={DateTime.Now.ToString("yyyy-MM-dd")}";
            var clinetRequest = new RestRequest(resourse, method: _configuration.MethodType);
            clinetRequest.AddHeader("apikey", _options.Value.AppKey);

            var restResponse = await client.ExecuteAsync(clinetRequest);
            if(restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.IsSuccessful) 
            {
                string content = restResponse.Content;
                response = JsonConvert.DeserializeObject<TRes>(content);
            }
            client.Dispose();
            return response;
        }
    }
}
