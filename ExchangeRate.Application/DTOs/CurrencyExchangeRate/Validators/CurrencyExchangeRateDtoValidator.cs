using ExchangeRate.Application.DTOs.CurrencyExchangeRate.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.DTOs.CurrencyExchangeRate.Validators
{
    public class CurrencyExchangeRateDtoValidator : AbstractValidator<CurrencyExchangeRateDto>
    {
        public CurrencyExchangeRateDtoValidator()
        {
            Include(new UpdateCurrencyExchangeRateDtoValidator());
            RuleFor(p => p.ExchangeRate)
                .NotNull()
                .GreaterThanOrEqualTo(0).WithMessage("Exchagne Rate Cannot be less then 0");
        }
    }
}
