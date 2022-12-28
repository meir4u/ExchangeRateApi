using ExchangeRate.ExchangeRatesApi.Base;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.ExchangeRatesApi.Client
{
    public abstract class ExchangeRateApiClient<TReq, TRes, TConfiguration> : IAction<TReq, TRes, TConfiguration>
        where TReq : IActionRequest
        where TRes : IActionResponse
        where TConfiguration : IActionConfiguration
    {
        private readonly TConfiguration configuration;

        public ExchangeRateApiClient(
            TConfiguration configuration
            )
        {
            this.configuration = configuration;
        }
        public async Task<TRes> Execute(TReq request)
        {
            TRes response = default(TRes);

            var option = new RestClientOptions();
            option.BaseUrl = new Uri(configuration.BaseUrl);
            option.MaxTimeout = -1;

            var client = new RestClient(option);
            var clinetRequest = new RestRequest(configuration.ApiUrl + configuration.AppKey + request.UrlQuery, method: configuration.MethodType);
            clinetRequest.AddHeader("apikey", configuration.AppKey);
            //clinetRequest.AddHeader("Content-Type", "text/plain");

            var restResponse = await client.ExecuteAsync(clinetRequest);
            if(restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.IsSuccessful) 
            {
                string content = restResponse.Content;
                response = JsonConvert.DeserializeObject<TRes>(content);
            }
            return response;
        }
    }
}
