using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TipoCambio.Service.Api.Models;
using TipoCambio.Service.Api.Services;

namespace TipoCambio.Service.Api.Features.CurrencyExchange.Commands
{
    public class CurrencyExchangeCommand : IRequest<int>
    {
        public int Type { get; set; }
        public string CurrencySource { get; set; }
        public string CurrencyDestination { get; set; }
        public decimal MoneySource { get; set; }
        public decimal MoneyDestination { get; set; }
        public string Created { get; set; }
        public class CurrencyExchangeCommandHandler : IRequestHandler<CurrencyExchangeCommand, int>
        {
            private readonly ICurrencyExchangeService _currencyExchangeService;
            public CurrencyExchangeCommandHandler(ICurrencyExchangeService currencyExchangeService)
            {
                _currencyExchangeService = currencyExchangeService;
            }
            public async Task<int> Handle(CurrencyExchangeCommand request, CancellationToken cancellationToken)
            {
                var currencyExchangeModel = new CurrencyExchangeModel()
                {
                    Type = request.Type,
                    CurrencySource = request.CurrencySource,
                    CurrencyDestination = request.CurrencyDestination,
                    MoneySource = request.MoneySource,
                    MoneyDestination = request.MoneyDestination,
                    Created = request.Created
                };
                return await _currencyExchangeService.CreateCurrency(currencyExchangeModel);
            }
        }
    }
}
