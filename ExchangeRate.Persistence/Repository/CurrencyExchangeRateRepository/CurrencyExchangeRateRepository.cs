using ExchangeRate.Application.Contract.Persistence;
using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Domain;
using ExchangeRate.Persistence.Repository.Base;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Persistence.Repository.CurrencyExchangeRateRepository
{
    public class CurrencyExchangeRateRepository : BaseFileRepository, ICurrencyExchangeRateRepository
    {
        private readonly IOptions<CurrencyExchangeRateRepositorySettings> _settings;

        public CurrencyExchangeRateRepository(IOptions<CurrencyExchangeRateRepositorySettings> settings)
        {
            this._settings = settings;
        }

        public IEnumerable<CurrencyExchangeRateDto> GetAll()
        {
            var data = this.ReadFromBinaryFile<IEnumerable<CurrencyExchangeRateDto>>(_settings.Value.FileFullPath);
            return data;
        }

        public void UpdateAll(IEnumerable<CurrencyExchangeRateDto> entity)
        {
            this.WriteToBinaryFile<IEnumerable<CurrencyExchangeRateDto>>(_settings.Value.FileFullPath, entity, false);
        }
    }
}
