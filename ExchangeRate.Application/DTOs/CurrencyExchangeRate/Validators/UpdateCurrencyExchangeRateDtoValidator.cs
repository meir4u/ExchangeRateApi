using ExchangeRate.Application.DTOs.CurrencyExchangeRate.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.DTOs.CurrencyExchangeRate.Validators
{
    public class UpdateCurrencyExchangeRateDtoValidator : AbstractValidator<ICurrencyExchangeRateDto>
    {
        public UpdateCurrencyExchangeRateDtoValidator()
        {
            RuleFor(p => p.CurrencyFrom)
                    .NotNull()
                    .NotEqual(Domain.EApi.Currency.None).WithMessage("From Currency Cann't be not set.");
            RuleFor(p => p.CurrencyTo)
                    .NotNull()
                    .NotEqual(Domain.EApi.Currency.None).WithMessage("To Currency Cann't be not set.");        

        }
    }
}
