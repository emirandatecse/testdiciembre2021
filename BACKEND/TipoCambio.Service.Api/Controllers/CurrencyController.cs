using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipoCambio.Service.Api.Features.CurrencyExchange.Commands;
using TipoCambio.Service.Api.Features.CurrencyExchange.Queries;
using TipoCambio.Service.Api.Models;

namespace TipoCambio.Service.Api.Controllers
{
    [ApiController]
    
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CurrencyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("health")]
        public async Task<string> Health()
        {
            string mensaje = "Todo OK";
            return mensaje;
        }
        
        [HttpPost("create")]
        [Authorize]
        public async Task<int> Create(CurrencyExchangeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("search")]
        [Authorize]
        public async Task<CurrencyExchangeResult> Search(GetCurrencyExchangeQuery query)
        {
            return await _mediator.Send(query); ;
        }
    }
}