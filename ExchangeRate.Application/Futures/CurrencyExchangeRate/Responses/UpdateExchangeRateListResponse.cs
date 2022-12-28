using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.Futures.CurrencyExchangeRate.Responses
{
    public class UpdateExchangeRateListResponse : BaseCommandResponse
    {
        public List<CurrencyExchangeRateDto> LeaveTypeDtos { get; set; }
    }
}
