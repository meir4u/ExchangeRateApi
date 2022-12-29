using ExchangeRate.Application.DTOs.CurrencyExchangeRate;
using ExchangeRate.Application.Futures.CurrencyExchangeRate.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExchangeRate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyExchangeRateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurrencyExchangeRateController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<ExchangeRateController>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CurrencyExchangeRateDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetExchangeRateListRequest());
            return Ok(result);
        }
    }
}
