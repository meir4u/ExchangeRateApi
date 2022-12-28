using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string key, object value) : base($"key:'{key}' value:'{value}' not found")
        {

        }
    }
}
