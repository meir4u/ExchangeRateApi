using AutoMapper;
using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CurrencyExchangeRate, CurrencyExchangeRateDto>().ReverseMap();
        }
    }
}
