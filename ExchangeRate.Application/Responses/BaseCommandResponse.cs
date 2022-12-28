﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Application.Responses
{
    public class BaseCommandResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = null;
    }
}
