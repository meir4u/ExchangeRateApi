using ExchangeRate.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.Contract.Persistence
{
    public interface ICurrencyExchangeRateRepository : IGenericRepository<CurrencyExchangeRate>
    {
    }
}
