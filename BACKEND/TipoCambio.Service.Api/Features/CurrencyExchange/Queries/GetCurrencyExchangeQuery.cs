using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TipoCambio.Service.Api.Services;
using MediatR;
using TipoCambio.Service.Api.Models;

namespace TipoCambio.Service.Api.Features.CurrencyExchange.Queries
{
    public class GetCurrencyExchangeQuery : IRequest<CurrencyExchangeResult>
    {
        public int Type { get; set; }
        public string CurrencyDestination { get; set; }
        public string CurrencySource { get; set; }
        public string Created { get; set; }

        public class GetCurrencyExchangeQueryHandler : IRequestHandler<GetCurrencyExchangeQuery, CurrencyExchangeResult>
        {
            private readonly ICurrencyExchangeService _currencyExchangeService;
            public GetCurrencyExchangeQueryHandler(ICurrencyExchangeService currencyExchangeService)
            {
                _currencyExchangeService = currencyExchangeService;
            }

            public async Task<CurrencyExchangeResult> Handle(GetCurrencyExchangeQuery request, CancellationToken cancellationToken)
            {
                var currencyExchangeModel = new CurrencyExchangeModel()
                {
                    Type = request.Type,
                    CurrencyDestination = request.CurrencyDestination,
                    CurrencySource = request.CurrencySource,
                    Created = request.Created
                };

                return await _currencyExchangeService.GetCurencyExchange(currencyExchangeModel);
            }
        }
    }
}
