using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.CurrencyDataAPI.Base
{
    public interface IAction<TReq, TRes, TConfiguration>
        where TReq : IActionRequest
        where TRes : IActionResponse
        where TConfiguration : IActionConfiguration
    {
        Task<TRes> Execute(TReq request);
    }
}
