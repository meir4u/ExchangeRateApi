using ExchangeRate.Provider.CurrencyDataAPI.Base;
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
        private readonly TConfiguration _configuration;

        public ExchangeRateApiClient(
            TConfiguration configuration
            )
        {
            this._configuration = configuration;
        }
        public async Task<TRes> Execute(TReq request)
        {
            TRes response = default(TRes);
            var option = new RestClientOptions();
            option.BaseUrl = new Uri(_configuration.BaseUrl);
            option.MaxTimeout = -1;

            var client = new RestClient(option);


            var resourse = _configuration.ApiUrl + _configuration.AppKey + request.UrlQuery + $"&date={DateTime.Now.ToString("yyyy-MM-dd")}";
            var clinetRequest = new RestRequest(resourse, method: _configuration.MethodType);
            clinetRequest.Timeout = -1;
            clinetRequest.AddHeader("apikey", _configuration.AppKey);

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
